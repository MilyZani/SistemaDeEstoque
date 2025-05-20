using System.Text.Json.Serialization;

namespace Projeto__Sistema_de_Estoque;

public abstract class Produto 
{
    [JsonPropertyName("nome")]
    public required string Nome { get; init; }
    
    [JsonPropertyName("preco")]
    public required float Preco { get; init; }
}
