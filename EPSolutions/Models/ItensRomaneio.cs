using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EPSolutions.Models;

public partial class ItensRomaneio
{
    
    public int Id { get; set; }

    public int IdRomaneio { get; set; }

    public string NrCaixa { get; set; } 

    public string DescrVolumes { get; set; } 

    public bool? Entregue { get; set; } 
   
    public required Romaneio IdRomaneioNavigation { get; set; } 
}
