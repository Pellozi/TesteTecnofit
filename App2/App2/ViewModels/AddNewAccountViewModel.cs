using App2.Models;
using App2.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App2.Views;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace App2.ViewModels
{
    public class AddNewAccountViewModel : BaseViewModel
    {

        string _token { get; set; }
        RestApi _rest = new RestApi();
        List<FormaCobranca> _listaFormaCobranca { get; set; }
        List<CategoriaConta> _listaCategoriaConta { get; set; }
        List<CentroResponsabilidade> _listaCentroResponsabilidade { get; set; }
        List<ContaBanco> _listaContaBanco { get; set; }

        ObservableCollection<string> _categoriaConta;
        ObservableCollection<string> _centroResponsabilidade;
        ObservableCollection<string> _contaBanco;
        public ICommand SaveAccountCommand { get; set; }

        #region Bindings

        string _eTitulo;
        public string ETitulo
        {
            get => _eTitulo;

            set
            {
                SetProperty(ref (_eTitulo), value);
            }
        }
        int _iFormaCobranca;
        public int IFormaCobranca
        {
            get => _iFormaCobranca;

            set
            {
                SetProperty(ref (_iFormaCobranca), value);
            }
        }
        int _iCategoriaConta;
        public int ICategoriaConta
        {
            get => _iCategoriaConta;

            set
            {
                SetProperty(ref (_iCategoriaConta), value);
            }
        }
        int _iCentroResponsabilidade;
        public int ICentroResponsabilidade
        {
            get => _iCentroResponsabilidade;

            set
            {
                SetProperty(ref (_iCentroResponsabilidade), value);
            }
        }
        int _iContaBanco;
        public int IContaBanco
        {
            get => _iContaBanco;

            set
            {
                SetProperty(ref (_iContaBanco), value);
            }
        }
        string _eValor;
        public string EValor
        {
            get => _eValor;

            set
            {
                SetProperty(ref (_eValor), value);
            }
        }

        string _eValorPago;
        public string EValorPago
        {
            get => _eValorPago;

            set
            {
                SetProperty(ref (_eValorPago), value);
            }
        }
        string _eValorDesconto;
        public string EValorDesconto
        {
            get => _eValorDesconto;

            set
            {
                SetProperty(ref (_eValorDesconto), value);
            }
        }
        string _eValorMulta;
        public string EValorMulta
        {
            get => _eValorMulta;

            set
            {
                SetProperty(ref (_eValorMulta), value);
            }
        }
        bool _switchStatus;
        public bool SwitchStatus
        {
            get => _switchStatus;

            set
            {
                SetProperty(ref (_switchStatus), value);
            }
        }

        DateTime _dataPagamento;
        public DateTime DataPagamento
        {
            get => _dataPagamento;

            set
            {
                SetProperty(ref (_dataPagamento), value);
            }
        }
        DateTime _dataVencimento;
        public DateTime DataVencimento
        {
            get => _dataVencimento;

            set
            {
                SetProperty(ref (_dataVencimento), value);
            }
        }

        ObservableCollection<string> _formaCobranca;
        public ObservableCollection<string> FormaCobranca
        {
            get => _formaCobranca;
            set
            {
                SetProperty(ref (_formaCobranca), value);
            }
        }


        public ObservableCollection<string> CategoriaConta
        {
            get => _categoriaConta;
            set
            {
                SetProperty(ref (_categoriaConta), value);
            }
        }
        public ObservableCollection<string> CentroResponsabilidade
        {
            get => _centroResponsabilidade;
            set
            {
                SetProperty(ref (_centroResponsabilidade), value);
            }
        }
        public ObservableCollection<string> ContaBanco
        {
            get => _contaBanco;
            set
            {
                SetProperty(ref (_contaBanco), value);
            }
        }

        #endregion


        public AddNewAccountViewModel(string tk)
        {
            _token = tk;
            GetNewAccount();
            SaveAccountCommand = new Command(SaveAccount);
            DataPagamento = DateTime.Now;
            DataVencimento = DateTime.Now;
        }

        Action SaveAccount => new Action(async () => await PostAccount());

        public async void GetNewAccount()
        {
            var asd = await _rest.Get<RootObject>("http://api.tecnofit.com.br/financeiro/conta-pr/1036/R", _token);
            _listaFormaCobranca = asd.parametros.formaCobranca;
            _listaCategoriaConta = asd.parametros.categoriaConta;
            _listaCentroResponsabilidade = asd.parametros.centroResponsabilidade;
            _listaContaBanco = asd.parametros.contaBanco;

            FormaCobranca = new ObservableCollection<string>();
            CategoriaConta = new ObservableCollection<string>();
            CentroResponsabilidade = new ObservableCollection<string>();
            ContaBanco = new ObservableCollection<string>();
            foreach (var forma in _listaFormaCobranca)
            {
                FormaCobranca.Add(forma.nome);
            }
            foreach (var formaCategoria in _listaCategoriaConta)
            {
                CategoriaConta.Add(formaCategoria.nome);
            }
            foreach (var formaCentroResponsabilidade in _listaCentroResponsabilidade)
            {
                CentroResponsabilidade.Add(formaCentroResponsabilidade.nome);
            }
            foreach (var formaConta in _listaContaBanco)
            {
                ContaBanco.Add(formaConta.nome);
            }
        }

        public async Task PostAccount()
        {


            var codigoFormaCobranca = Convert.ToInt32(_listaFormaCobranca[IFormaCobranca].id);
            var codigoCategoriaConta = Convert.ToInt32(_listaCategoriaConta[ICategoriaConta].id);
            var codigoCentroResponsabilidade = Convert.ToInt32(_listaCentroResponsabilidade[ICentroResponsabilidade].id);
            var codigoContaBanco = Convert.ToInt32(_listaContaBanco[IContaBanco].id);
            string dateTimePagamento = _dataPagamento.Date.ToString("yyyy'-'M'-'dd");
            string dateTimeVencimento = _dataVencimento.Date.ToString("yyyy'-'M'-'dd");
            decimal valorConta = Convert.ToDecimal(EValor);
            decimal valorPagoConta = Convert.ToDecimal(EValorPago);
            decimal valorDescontoConta = Convert.ToDecimal(EValorDesconto);
            decimal valorMultaConta = Convert.ToDecimal(EValorMulta);
            int statusConta;

            if (_switchStatus == true)
            {
                statusConta = 1;
            }
            else
            {
                statusConta = 0;
            }

            NewAccount ac = new NewAccount()
            {
                id = null,
                empresaId = 1036,
                tipoConta = "R",
                formaCobrancaId = null,
                historico = _eTitulo,
                categoriaContaId = codigoCategoriaConta,
                formaPagamentoId = codigoFormaCobranca,
                centroResponsabilidadeId = codigoCentroResponsabilidade,
                contaBancoId = codigoContaBanco,
                dataPagamento = dateTimePagamento,
                dataVencimento = dateTimeVencimento,
                valor = valorConta,
                valorPago = valorPagoConta,
                valorDesconto = valorDescontoConta,
                valorMulta = valorMultaConta,
                status = statusConta
            };

            var post = await _rest.Post(ac, "http://api.tecnofit.com.br/financeiro/conta-pr/cadastro");
            if (post == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", (string)post, "Ok");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Conta salva", "Conta salva com sucesso", "Okay", "Cancel");
                await App.Current.MainPage.Navigation.PopModalAsync(); 

            }
        }
    }
}
