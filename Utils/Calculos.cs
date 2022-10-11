namespace API.Utils
{   
    public class Calculos
    {
        public static double CalcularSalarioBruto( int quantidadeDeHoras, double valorHora) => quantidadeDeHoras * valorHora;

        public static double CalcularIRRF( double bruto)
        {
            if(bruto <=1903.98) return  0;
                
            if (bruto <= 2826.65) return  (bruto * 0.075) - 142.8;

            if(bruto <= 3751.05) return  (bruto*0.15)-354.8;
               
            if (bruto<=4664.68) return  (bruto * 0.225)-636.13;
                                
             return  (bruto*0.275)-869.39;  
        }
    }
}