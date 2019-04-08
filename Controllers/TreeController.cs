using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using MasivianProject.BI;
using MasivianProject.BI.BindingModels;

namespace MasivianProject.Controllers
{
    public class TreeController : ApiController
    {
        [HttpPost]
        [Route("Api/GetAncestor")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public string Ancestor(TreeModel tree)
        {
            string result = string.Empty;

            try
            {
                TreeLogic treeLogic = new TreeLogic(tree);
                bool err = false;
                string ancestor = treeLogic.GetAncestor(tree.Child1, tree.Child2, ref err);

                if (err)
                {
                    result = ancestor;
                }
                else
                {
                    result = $"El ancestro más cercado entre {tree.Child1} y {tree.Child2} es {ancestor}";
                }

                return result;
            }
            catch (Exception ex)
            {
                result = $"Ocurrio un error inesperado. El error generado es el siguiente: {ex.Message}";
                return result;
            }
        }
    }
}