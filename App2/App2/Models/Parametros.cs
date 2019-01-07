using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    class Parametros
    {
        public List<FormaCobranca> formaCobranca { get; set; }
        public List<CategoriaConta> categoriaConta { get; set; }
        public List<CentroResponsabilidade> centroResponsabilidade { get; set; }
        public List<ContaBanco> contaBanco { get; set; }

    }
}
