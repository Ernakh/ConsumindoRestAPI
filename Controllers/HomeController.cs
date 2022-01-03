using ConsumindoRestAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ConsumindoRestAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            return View();
        }

        public async Task<ActionResult> Pessoas()
        {
            string Baseurl = "http://localhost:5258/";

            List<Pessoa>? pessoas = new List<Pessoa>();
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage Res = await client.GetAsync("api/pessoas");

            if (Res.IsSuccessStatusCode)
            {
                var response = Res.Content.ReadAsStringAsync().Result;
                pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(response);
            }


            return View(pessoas);
        }

        public async Task<ActionResult> PessoaId(int id)
        {
            string Baseurl = "http://localhost:5258/";

            Pessoa? p = new Pessoa();
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage Res = await client.GetAsync("api/pessoas/" + id);

            if (Res.IsSuccessStatusCode)
            {
                var response = Res.Content.ReadAsStringAsync().Result;
                p = JsonConvert.DeserializeObject<Pessoa>(response);
            }

            return View(p);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(Pessoa p)
        {
            string Baseurl = "http://localhost:5258/";
            HttpClient client = new HttpClient();

            HttpResponseMessage Res = await client.PostAsJsonAsync(Baseurl + "api/pessoas", p);

            //if (Res.IsSuccessStatusCode)
            //{
            //}
                return RedirectToAction("pessoas");

            /*
              //{   //PUT
            //    Uri chaUrl = Res.Headers.Location;
            //    cha.Preco = 2.55M;   // atualiza o preco do produto
            //    response = await client.PutAsJsonAsync(chaUrl, cha);
            //    Console.WriteLine("Produto preço do atualizado. Tecle algo para excluir o produto");
            //    Console.ReadKey();
            //    //DELETE
            //    response = await client.DeleteAsync(chaUrl);
             
             */
        }

        public IActionResult Alterar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Alterar(Pessoa p, int id)
        {
            string Baseurl = "http://localhost:5258/";
            HttpClient client = new HttpClient();

            HttpResponseMessage Res = await client.PutAsJsonAsync(Baseurl + "api/pessoas/" + id, p);

            if (Res.IsSuccessStatusCode)
            {
            }
            return RedirectToAction("pessoas");
        }
        public IActionResult Excluir()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Excluir(int id)
        {
            string Baseurl = "http://localhost:5258/";
            HttpClient client = new HttpClient();

            HttpResponseMessage Res = await client.DeleteAsync(Baseurl + "api/pessoas/" + id);

            if (Res.IsSuccessStatusCode)
            {

            }
            return RedirectToAction("pessoas");

        }
        }
    }
