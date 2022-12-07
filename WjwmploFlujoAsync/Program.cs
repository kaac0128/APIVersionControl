using WjwmploFlujoAsync;
using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

Console.WriteLine("\nBienvenido a la calculadora de hipotecas sincrona");

var aniosVidaLaboral = CalculadoraHipotecaSync.obetenerAniosVidaLaboral();
Console.WriteLine($" \nAños de Vida Laboral Obtenidos: {aniosVidaLaboral}");

 var esTipoContratoIndefinido = CalculadoraHipotecaSync.EsTipoContratoIndefinido();
Console.WriteLine($"\nTipo de contrato indefinido: {esTipoContratoIndefinido}");

var sueldoNeto = CalculadoraHipotecaSync.ObtenerSueldoNeto();
Console.WriteLine($" \nSueldo neto obtenido: {sueldoNeto}" ) ;

var gastosMensuales = CalculadoraHipotecaSync.ObtenerGatosMensuales();
Console.WriteLine($"\nGastos Mensuales obtenidos: {gastosMensuales}");

var hipotecaConcedida = CalculadoraHipotecaSync.AnalizarInformacionParaConcederHipoteca(
    aniosVidaLaboral, esTipoContratoIndefinido, sueldoNeto, gastosMensuales, cantidadSolicitada: 50000, aniosPagar: 30);

var resultado = hipotecaConcedida ? "APROBADA" : "DENEGADA";
Console.WriteLine($"inAnálisis Finalizado. Su solicitud de hipoteca ha sido: {resultado}");
stopwatch.Stop();
Console.WriteLine($"\nGastos Mensuales obtenidos: {stopwatch.Elapsed}");

//


stopwatch.Restart();
Console.WriteLine("\n**************************************************");
Console.WriteLine("\nBienvenido a la calculadora de hipotecas asincrona");
Console.WriteLine("\n**************************************************");

Task<int> aniosVidaLaboralTask = CalculadoraHipotecaAsync.obetenerAniosVidaLaboral();
Task<bool> esTipoContratoIndefinidoTask = CalculadoraHipotecaAsync.EsTipoContratoIndefinido();
Task<int> sueldoNetoTask = CalculadoraHipotecaAsync.ObtenerSueldoNeto();
Task<int> gastosMensualesTask = CalculadoraHipotecaAsync.ObtenerGatosMensuales();

var analisisHipotecaTasks = new List<Task>
{
    aniosVidaLaboralTask,
    esTipoContratoIndefinidoTask,
    sueldoNetoTask,
    gastosMensualesTask
};

while (analisisHipotecaTasks.Any())
{
    Task tareaFinalizada = await Task.WhenAny(analisisHipotecaTasks);

    if (tareaFinalizada == aniosVidaLaboralTask)
    {
        Console.WriteLine($" \nAños de Vida Laboral Obtenidos: {aniosVidaLaboralTask.Result}");
    }
    else if (tareaFinalizada == esTipoContratoIndefinidoTask)
    {
        Console.WriteLine($"\nTipo de contrato indefinido: {esTipoContratoIndefinidoTask.Result}");
    }
    else if(tareaFinalizada == sueldoNetoTask)
    {
        Console.WriteLine($" \nSueldo neto obtenido: {sueldoNetoTask.Result}");
    }
    else if(tareaFinalizada == gastosMensualesTask)
    {
        Console.WriteLine($"\nGastos Mensuales obtenidos: {gastosMensualesTask.Result}");
    }

    analisisHipotecaTasks.Remove(tareaFinalizada);
}

var hipotecaAsyncConcedida = CalculadoraHipotecaAsync.AnalizarInformacionParaConcederHipoteca(
    aniosVidaLaboralTask.Result, esTipoContratoIndefinidoTask.Result, sueldoNetoTask.Result, gastosMensualesTask.Result, cantidadSolicitada: 50000, aniosPagar: 30);

var resultadoAsync = hipotecaAsyncConcedida ? "APROBADA" : "DENEGADA";
Console.WriteLine($"inAnálisis Finalizado. Su solicitud de hipoteca ha sido: {resultadoAsync}");
stopwatch.Stop();
Console.WriteLine($"\nGastos Mensuales obtenidos: {stopwatch.Elapsed}");
Console.Read();