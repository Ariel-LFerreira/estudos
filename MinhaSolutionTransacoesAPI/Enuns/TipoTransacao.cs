namespace MinhaSolutionTransacoesAPI.Enuns;

using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TipoTransacao
{
    Saque = 1,
    Transferencia = 2,
    PIX = 3,
    Deposito = 4,
}