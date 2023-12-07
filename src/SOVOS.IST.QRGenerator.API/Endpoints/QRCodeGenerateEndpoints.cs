

namespace SOVOS.IST.QRGenerator.API.Endpoints
{
    public static class QRCodeGenerateEndpoints
    {
        public static void MapQRGenerateEndpoints(this WebApplication app)
        {
            app.MapGet("/qr", async (string data) =>
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(data))
                    {
                        Log.Error("The 'data' parameter cannot be empty.");
                        return Results.BadRequest("The 'data' parameter cannot be empty.");
                    }
                    QRData qrData = JsonSerializer.Deserialize<QRData>(data);
                    var validationResults = new List<ValidationResult>();
                    var validationContext = new ValidationContext(qrData, serviceProvider: null, items: null);
                    bool isValid = Validator.TryValidateObject(qrData, validationContext, validationResults, validateAllProperties: true);
                    if (!isValid)
                    {
                        string errorMessage = String.Join(" / ", validationResults.Select(x => x.ErrorMessage));
                        Log.Error(errorMessage);
                        return Results.BadRequest(errorMessage);
                    }
                    byte[] result = await Task.Run(() => QRCoderHelper.Generate(data));
                    Log.Debug($"QR code generated for '{data}'");
                    return Results.File(result, "Image/png");
                }
                catch (JsonException ex)
                {
                    Log.Error($"Json error: {ex.Message}");
                    return Results.BadRequest("Can not convert JSON format.");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error occurred while generating QR code for '{data}'");
                    return Results.StatusCode(500);
                }
            });
        }
    }
}
