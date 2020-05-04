using Newtonsoft.Json;
using PsicoMost.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PsicoMost.Service
{
    public class DataService
    {
        //HttpClient Client = new HttpClient();

        //public async Task<bool> LogarUsuario(Usuario usuario)
        //{
        //    try
        //    {
        //        string url = "http://localhost:60042/api/Usuario?crp={crp}&senha={senha}";
        //        var t = await Client.GetStringAsync(url);
        //        var usuarios = JsonConvert.DeserializeObject<bool>(t);

        //        //var uri = new Uri(string.Format(url, usuario.CRP, usuario.Senha));
        //       // var data = JsonConvert.SerializeObject(usuario); 
                
        //       // var content = new StringContent(data, Encoding.UTF8, "application/json");
               
        //        //HttpResponseMessage response = null;
        //        //response = await Client.GetAsync(uri);

        //        if (!usuarios)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}
