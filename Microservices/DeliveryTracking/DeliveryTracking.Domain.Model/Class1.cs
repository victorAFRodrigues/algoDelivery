
using System.Text.Json;

namespace DeliveryTracking.Domain.Model;

List<ItemRateio> rateio = JsonSerializer.Deserialize<List<ItemRateio>>(observacao);
                        
public class ItemRateio
{
    public string  DEPARTAMENTO { get; set; }
    public decimal VALOR { get; set; }
    public decimal PORCENTAGEM { get; set; }
    
    public string MsgFormatada = "DEPARTAMENTO: " + DEPARTAMENTO + " | " + 
                                               "VALOR: " + VALOR + " | " + 
                                               "PORCENTAGEM: " + PORCENTAGEM + " | ";
};
                        
var FormataJson = (ItemRateio item) =>
{
    return "DEPARTAMENTO: " + item.DEPARTAMENTO + " | " + 
           "VALOR: " + item.VALOR + " | " + 
           "PORCENTAGEM: " + item.PORCENTAGEM + " | ";
}

var observacao = " dad ".Trim();
Console.WriteLine(observacao);

observacao = string.Join("", rateio.Select(FormataJson));
