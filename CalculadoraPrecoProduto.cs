namespace Test_hiplatform
{
    /// <summary>
    /// Classe responsável por calcular o custo e preço do produto
    /// </summary>
    public class CalculadoraPrecoProduto
    {
        private readonly double _lucroPadrao;
        private readonly double _lucroProdutosProximoExpiracao;

        /// <summary>
        /// Método responsável por instanciar o objeto 
        /// </summary>
        /// <param name="lucroPadrao">lucro padrão</param>
        /// <param name="lucroProdutosProximoExpiracao">lucro dos produtos próximos a expirar</param>
        /// <exception cref="Exception"></exception>
        public CalculadoraPrecoProduto(double lucroPadrao, double lucroProdutosProximoExpiracao)
        {
            if (lucroPadrao <= 0) throw new Exception("informe o lucro padrão");
            if (lucroProdutosProximoExpiracao <= 0) throw new Exception("informe o lucro dos produtos próximos a expirar");

            _lucroPadrao = lucroPadrao;
            _lucroProdutosProximoExpiracao = lucroProdutosProximoExpiracao;

        }
        /// <summary>
        /// Método responsável por calcular o custo do produto
        /// </summary>
        /// <param name="custoAquisicao">custo de aquisição</param>
        /// <param name="volumeOcupado">volume ocupado</param>
        /// <param name="refrigeracao">necessita de refrigeração</param>
        /// <param name="riscoExpiracao">possui risco de expiração</param>
        /// <returns></returns>
        public double CalcularCustoProduto(double custoAquisicao, double volumeOcupado, bool refrigeracao, bool riscoExpiracao)
        {
            if (custoAquisicao <= 0) throw new Exception("informe o custo de aquisição");
            if (volumeOcupado <= 0) throw new Exception("informe o volume ocupado");

            double baseCusto = (volumeOcupado / 2) / 100;

            if (refrigeracao)
            {
                baseCusto += 0.05;
            }

            if (riscoExpiracao)
            {
                baseCusto += 0.07;
            }

            double resultado = custoAquisicao + (custoAquisicao * baseCusto);

            return resultado;
        }

        /// <summary>
        /// Método responsável por calcular o preço do produto
        /// </summary>
        /// <param name="custo">custo do produto</param>
        /// <param name="validade">validade do produto em dias</param>
        /// <returns></returns>
        public double FormulaMagica(double custo, int validade)
        {
            if (custo <= 0) throw new Exception("informe o custo do produto");
            if (validade < 0) throw new Exception("validade não pode ser negativa");

            double lucro = _lucroPadrao;

            if (validade < 7)
            {
                lucro = _lucroProdutosProximoExpiracao;
            }

            double basePreco = lucro / 100;

            double resultado = custo + (custo * basePreco);

            return resultado;
        }
    }
}
