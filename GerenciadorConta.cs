namespace Test_hiplatform
{
    using System.Transactions;

    public class GerenciadorConta
    {
        private readonly ContaDao contaDao;

        public void Debitar(long idConta, double valor)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                Conta conta = contaDao.BuscaConta(idConta);
                if (conta.PodeDebitar(valor))
                {
                    conta.Debite(valor);
                    contaDao.Atualiza(conta);
                    tran.Complete();
                }
                else
                {
                    tran.Dispose();
                    throw new SaldoInsuficienteException();
                }
            }
        }

        public void creditar(long idConta, double valor)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                Conta conta = contaDao.BuscaConta(idConta);
                conta.Credite(valor);
                contaDao.Atualiza(conta);
                tran.Complete();
            }
        }

        #region Classes
        abstract class Conta
        {
            public abstract bool PodeDebitar(double valor);
            public abstract void Debite(double valor);
            public abstract void Credite(double valor);
        }

        interface ContaDao
        {
            Conta BuscaConta(long idConta);
            void Atualiza(Conta conta);
        }

        public class SaldoInsuficienteException : Exception { }
        #endregion
    }
}
