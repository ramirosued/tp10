using Microsoft.AspNetCore.Mvc;

namespace tp10.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.ListaSeries=BD.TraerSeries();
        return View();
    }

    public Series VerDetalleSerie(int IdSerie){
        return BD.GetSerie(IdSerie);
    }

     public List<string> VerTemporadasSerie(int IdSerie){
        return BD.GetTemporadas(IdSerie);
    }

     public List<string> VerActoresSerie(int IdSerie){
        return BD.GetActores(IdSerie);
    }
}

