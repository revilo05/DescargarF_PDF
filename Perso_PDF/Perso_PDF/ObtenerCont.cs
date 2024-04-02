using System;
using Microsoft.AspNetCore.Mvc;
using Perso_PDF;

[ApiController]
[Route("PDF")]
public class PdfController : ControllerBase
{
    private readonly PdfGenerator _pdfGenerator;

    public PdfController(PdfGenerator pdfGenerator)
    {
        _pdfGenerator = pdfGenerator;
    }

    [HttpGet("Generador")]
    public IActionResult DescargarPDF(string Contenido)
    {
        try
        {
            string contenidoHtml = @"<!DOCTYPE html>
<html lang = 'es'>
 <head>
 
   <meta charset = 'UTF-8'>
  
   <title> Formulario de solicitud de crédito</ title>
     
      <style>
         body {
                font-family: Arial, sans-serif;
            margin: 20px;
            }

            h1 {
                text-align: center;
            }

            form {
                max-width: 600px;
            margin: 0 auto;
            }

    .campo {
                margin-bottom: 15px;
            }

            label {
            display: block;
                margin-bottom: 5px;
            }

    .datos-personales {
            border: 1px solid #fbfbfb;
      padding: 15px;
                border-radius: 5px;
                background-color: #f9f9f9;
    }


    .Dp {
                background-color: #000000;
  color: #f9f9f9;
  text-align: center;
            padding: 10px;
            margin: 0;
                border-radius: 5px;
            }

.datos-personales {
            border: 1px solid #fbfbfb;
  padding: 15px;
                border-radius: 5px;
                background-color: #f9f9f9;

}

.campo {
                margin-bottom: 15px;
            }

            label {
            display: block;
                margin-bottom: 5px;
            }

.Dp-label {
                font-size: 18px;
                font-weight: bold;
                margin-bottom: 10px;
            }
.info-actividad {
            border: 1px solid #fbfbfb;
      padding: 15px;
                border-radius: 5px;
                background-color: #f9f9f9;
      margin-top: 10px;
            }

    .InfoAct {
                background-color: #5f5e5e;
      color: #f9f9f9;
      text-align: center;
            padding: 10px;
            margin: 0;
                border-radius: 5px;
            }

    .InfoAct-label {
                font-size: 18px;
                font-weight: bold;
                margin-bottom: 20px;
            }
    .pep-info {
            border: 1px solid #fbfbfb;
      padding: 15px;
                border-radius: 5px;
                background-color: #f9f9f9;
      margin-top: 10px;
            }

    .PepInfo {
                background-color: #5f5e5e;
      color: #f9f9f9;
      text-align: center;
            padding: 10px;
            margin: 0;
                border-radius: 5px;
            }

    .PepInfo-label {
                font-size: 18px;
                font-weight: bold;
                margin-bottom: 20px;
            }
    .conyuge-info {
            border: 1px solid #fbfbfb;
      padding: 15px;
                border-radius: 5px;
                background-color: #f9f9f9;
      margin-top: 10px;
            }

    .ConyugeInfo {
                background-color: #5f5e5e;
      color: #f9f9f9;
      text-align: center;
            padding: 10px;
            margin: 0;
                border-radius: 5px;
            }

    .ConyugeInfo-label {
                font-size: 18px;
                font-weight: bold;
                margin-bottom: 20px;
            }
    .operacion-info {
            border: 1px solid #fbfbfb;
      padding: 15px;
                border-radius: 5px;
                background-color: #f9f9f9;
      margin-top: 10px;
            }

    .OperacionInfo {
                background-color: #000000;
      color: #f9f9f9;
      text-align: center;
            padding: 10px;
            margin: 0;
                border-radius: 5px;
            }

    .OperacionInfo-label {
                font-size: 18px;
                font-weight: bold;
                margin-bottom: 20px;
            }


    .credit-info {
            border: 1px solid #fbfbfb;
      padding: 15px;
                border-radius: 5px;
                background-color: #f9f9f9;
      margin-top: 10px;
            }

    .CreditInfo {
                background-color: #5f5e5e;
      color: #f9f9f9;
      text-align: center;
            padding: 10px;
            margin: 0;
                border-radius: 5px;
            }

    .CreditInfo-label {
                font-size: 18px;
                font-weight: bold;
                margin-bottom: 20px;
            }
    .referencias-info {
            border: 1px solid #fbfbfb;
      padding: 15px;
                border-radius: 5px;
                background-color: #f9f9f9;
      margin-top: 10px;
            }

    .ReferenciasInfo {
                background-color: #5f5e5e;
      color: #f9f9f9;
      text-align: center;
            padding: 10px;
            margin: 0;
                border-radius: 5px;
            }

    .ReferenciasInfo-label {
                font-size: 18px;
                font-weight: bold;
                margin-bottom: 10px;
            }
    .Notas{
            color: #000000;
        font-size: 10px;
                font-weight: bold;
                margin-bottom: 10px;
                margin-top: 20px;
            }

    .firma {
                margin-top: 30px;
                text-align: center;
            }

    .firma h2 {
                font-size: 18px;
            color: #333;
    }

    .declaracion {
                background-color: #090606;
      border: 1px solid #ddd;
      border-radius: 10px;
            padding: 20px;
                margin-top: 20px;
                box-shadow: 0 0 10px rgb(255, 225, 0)
    }

    .declaracion p {
            color: #ddd;
        margin-bottom: 15px;
            }

    .declaracion h2 {
                font-size: 24px;
            color: #ffffff;
      text-align: center;
                margin-bottom: 20px;
            }

    .declaracion.firma {
                margin-top: 30px;
            }

    .declaracion.firma h2 {
                font-size: 20px;
            }
            p.separator {
                text-align: center;
                font-size: 18px;
            margin: 20px 0;
            position: relative;
            }

            p.separator::before,
p.separator::after {
            content: '';
            display: inline-block;
            width: 40 %;
            height: 2px;
                background-color: #333;
  vertical-align: middle;
            }

            p.separator::before {
                margin-right: 10px;
            }

            p.separator::after {
                margin-left: 10px;
            }

            ul {
                list-style: none;
            padding: 0;
            }

            ul li {
                margin-bottom: 10px;
            }

            ul li strong {
            color: #ffb004; 
    }

            table {
            width: 100 %;
                border-collapse: collapse;
                margin-top: 20px;
            }

            table, th, td {
            border: 1px solid #ffb004;
    }

            th, td {
            padding: 8px;
                text-align: left;
            }

            th {
                background-color: #f2f2f2;
    }

            p {
                margin-top: 20px;
            color: #555;
      font-size: 14px;
            }
            img {
                max-width: 30 %;
            height: auto;
                border-radius: 10px;
                margin-top: 20px;
                margin-left: 35 %;
                box-shadow: 0 0 10px rgba(255, 255, 255, 0.1);
            }
    
  
    .contenido {
            padding: 20px;
            transition: background-color 0.3s ease;
                border-radius: 5px;
            }  .contenido2 {
            padding: 20px;
            transition: background-color 0.3s ease;
                border-radius: 5px;
            }  .contenido23 {
            padding: 20px;
            transition: background-color 0.3s ease;
                border-radius: 5px;
            }  .contenido25 {
            padding: 20px;
            transition: background-color 0.3s ease;
                border-radius: 5px;
            }  .contenido3 {
            padding: 20px;
            transition: background-color 0.3s ease;
                border-radius: 5px;
            }  .contenido4 {
            padding: 20px;
            transition: background-color 0.3s ease;
                border-radius: 5px;
            }
  .contenido5 {
            padding: 20px;
            transition: background-color 0.3s ease;
                border-radius: 5px;
            }
  .contenido6 {
            padding: 20px;
            transition: background-color 0.3s ease;
                border-radius: 5px;
            }
    .contenido7 {
            padding: 20px;
            transition: background-color 0.3s ease;
                border-radius: 5px;
            }
  
  .check {
                margin-left: 605px;
            }


  </style>

</head>
<body>

    <img src='https://www.santodomingomotors.com.do/wp-content/uploads/2023/01/271966235_10159105544178929_7575951278983518837_n.jpg' alt='Descripción de la imagen'>
   <h1> FORMULARIO DE INFORMACIÓN DEL CLIENTE / SOLICITUD DE CRÉDITO
    PERSONA FISICA</h1>
  <form action='' method='post'>
@Contenido
  </form>

</body>
</html> ";

            contenidoHtml = contenidoHtml.Replace("@Contenido", Contenido);

            byte[] fileContents = _pdfGenerator.GeneratePdf(contenidoHtml);

            string contentType = "application/pdf";
            string fileDownloadName = "Reporte_compra.pdf";

            return File(fileContents, contentType, fileDownloadName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al generar el PDF: {ex.Message}");
            return StatusCode(500, "Error interno del servidor" + ex);
        }
    }
}
