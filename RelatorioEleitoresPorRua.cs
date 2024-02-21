namespace Test_hiplatform
{
    using System.Collections.Generic;
    using Test_hiplatform.Models;

    public class RelatorioEleitoresPorRua
    {
        public List<Rua> ObterRuasOrdenandaPorEleitores(List<Casa> casas)
        {
            List<Rua> resultado = casas.OrderByDescending(x => x.TotalEleitores).Select(x => x.Rua).ToList();
            return resultado;
        }
    }
}
