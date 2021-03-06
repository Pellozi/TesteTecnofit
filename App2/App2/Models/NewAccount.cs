﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    class NewAccount
    {
        public object id { get; set; }
        public int empresaId { get; set; }
        public string tipoConta { get; set; }
        public int categoriaContaId { get; set; }
        public int centroResponsabilidadeId { get; set; }
        public int formaPagamentoId { get; set; }
        public object formaCobrancaId { get; set; }
        public int contaBancoId { get; set; }
        public string dataVencimento { get; set; }
        public string dataPagamento { get; set; }
        public string historico { get; set; }
        public decimal valor { get; set; }
        public decimal valorPago { get; set; }
        public decimal valorDesconto { get; set; }
        public decimal valorMulta { get; set; }
        public int status { get; set; }
    }
}
