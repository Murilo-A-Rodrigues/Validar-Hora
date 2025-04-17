namespace ConsoleApp.Modelos;

public class Compromisso
{
    private DateTime _data;
    public String Data
    {
        get { return _data.ToString(); }
        set
        {
            _validarDataInformada(value);
            _validarDataValidaParaCompromisso();
        }
    }

    private TimeSpan _hora;
    public TimeSpan Hora 
    { 
        get{return _hora; } 
        set 
        {
            _validarHoraInformada(value);
            _hora = value;
            _validarHoraValidaParaCompromisso();
        }
        }
    public string Descricao { get; set; }
    public string Local { get; set; }

    private void _validarDataInformada(string data) {
        if (!DateTime.TryParseExact(data,
                       "dd/MM/yyyy",
                       System.Globalization.CultureInfo.GetCultureInfo("pt-BR"),
                       System.Globalization.DateTimeStyles.None,
                       out _data))
        {
            throw new Exception($"Data {data} Inválida!");
        }
    }

    private void _validarDataValidaParaCompromisso() {
        if (_data<=DateTime.Now) {
            throw new Exception($"Data {_data.ToString("dd/MM/yyyy")} é inferior a permitida.");
        }
        // if (_data == null) {
        //     throw new Exception("Data ainda não informada");
        // }
    }
     private void _validarHoraInformada(TimeSpan hora) {
        if (hora < TimeSpan.Zero || hora >= TimeSpan.FromDays(1))
    {
        throw new Exception($"Hora {hora:hh\\:mm} inválida.");
    }
        }


    private void _validarHoraValidaParaCompromisso() {
        if (_hora < TimeSpan.FromHours(7) || _hora > TimeSpan.FromHours(22)) {
            throw new Exception($"Hora {_hora.ToString(@"hh\:mm")} é muito tarde/cedo para marcar compromisso.");
        }
    }
    // private TimeSpan _hora;
    // public TimeSpan Hora
    // {
    //     get { return _hora; }
    //     set { _hora = value; }
    // }

    // private DateTime _data;

    // public DateTime Data {
    //     get {
    //         return _data;
    //     }
    //     set {
    //         _data = value;
    //     }
    // }

    // public string DataBR() {
    //     return _data.ToString("dd/MM/yyyy");
    // }

    // public void RegistrarData(DateTime data) {
    //     _data = data;
    // }

    // public DateTime ObterData() {
    //     return _data;
    // }
}
