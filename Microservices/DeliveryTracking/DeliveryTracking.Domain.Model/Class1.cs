
using System.Text.Json;

namespace DeliveryTracking.Domain.Model;

List<ItemRateio> rateio = JsonSerializer.Deserialize<List<ItemRateio>>(observacao);
                        
public class ItemRateio
{
<<<<<<< HEAD
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
=======
    private static int S1 { get; set; }
    
    public Class1(int s1){ S1 = s1; }
    public static void Main()
    {   
        if (S1.Equals(1))
        {
            Console.WriteLine(S1);
        } else 
            {
            Console.WriteLine(S1);
            }
    }
    
    Class1 init = new Class1(1);
}
>>>>>>> c1411e787a5580ebb4ce444e3d23fe7205180d2a
