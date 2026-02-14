namespace MinhaSolutionTransacoesAPI.Enuns;

using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TipoConta
{
    Corrente = 1,
    Poupanca = 2,
}