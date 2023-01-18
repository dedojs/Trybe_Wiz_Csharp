namespace Comex.Utils
{
    public static class Correios
    {
        /// <summary>
        /// Método que calcula vaor do frente baseado no CEP informado
        /// </summary>
        /// <param name="cepEntry">Cep da região: 11111-111</param>
        /// <returns>Retorna o valor referente ao frete.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static char ObterRegiaoPorCEP(string cepEntry)
        {
            var validate = ValidateCep(cepEntry);

            if (validate == null)
            {
                throw new ArgumentException("Cep inválido");
            }

            char region = validate[0];
            
            return region;
        }

        private static string ValidateCep(string cepEntry)
        {
            var value = cepEntry.Trim().Split('-');
            var cep = string.Concat(value[0], value[1]);

            if (string.IsNullOrEmpty(cepEntry))
            {
                throw new NullReferenceException("Necessário informar o valor do cep");
            }

            var isNumeric = int.TryParse(cep, out _);

            if (!isNumeric || cep.Length != 8)
            {
                throw new ArgumentException("Cep informado não corresponde ao padrão aceito: xxxxx-xxx");
            }

            return cep;
        }
    }
}