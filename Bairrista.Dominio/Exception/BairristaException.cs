using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bairrista.Dominio
{
    public class BairristaException : Exception
    {
        public BairristaMenssage BairristaMenssage { get; set; }
        public ExceptionEnum StatusCode { get; set; } = ExceptionEnum.BadRequest;
        public string ContentType { get; set; } = @"text/json";

        public BairristaException() : base()
        {
        }

        public BairristaException(string message) : base(message)
        {
            this.BairristaMenssage = new BairristaMenssage { Codigo = this.StatusCode.ToString(), Messagem = message };
        }
        public BairristaException(ExceptionEnum status, string message) : base(message)
        {
            this.StatusCode = status;
            this.BairristaMenssage = new BairristaMenssage { Codigo = this.StatusCode.ToString(), Messagem = message };
        }

        public BairristaException(ExceptionEnum status, string message, List<BairristaError> erros) : base(message)
        {
            this.StatusCode = status;
            this.BairristaMenssage = new BairristaMenssage { Codigo = this.StatusCode.ToString(), Messagem = message, Erros = erros };
        }

        public BairristaException(ExceptionEnum status, List<BairristaError> erros)
        {
            this.StatusCode = status;
            if (erros.Count > 0)
                this.BairristaMenssage = new BairristaMenssage { Codigo = erros.FirstOrDefault().Codigo, Messagem = erros.FirstOrDefault().Messagem, Erros = erros };
        }

        public BairristaException(ExceptionEnum status, BairristaMenssage menssage)
        {
            this.StatusCode = status;
            this.BairristaMenssage = menssage;
        }

        public BairristaException(string message, Exception innerException) : base(message, innerException)
        {
            this.BairristaMenssage = new BairristaMenssage { Codigo = this.StatusCode.ToString(), Messagem = message, Reference = innerException };
        }

        public BairristaException(ExceptionEnum status, string message, Exception innerException) : base(message, innerException)
        {
            this.StatusCode = status;
            this.BairristaMenssage = new BairristaMenssage { Codigo = this.StatusCode.ToString(), Messagem = message, Reference = innerException };
        }

        public BairristaException(ExceptionEnum status, string message, Exception innerException, List<BairristaError> erros) : base(message, innerException)
        {
            this.StatusCode = status;
            this.BairristaMenssage = new BairristaMenssage { Codigo = this.StatusCode.ToString(), Messagem = message, Reference = innerException, Erros = erros };
        }

        internal static BairristaException DeserializeObject(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<BairristaException>(json);
            }
            catch
            {
                return new BairristaException();
            }
        }

        internal string SerializeObject()
        {
            try
            {
                return JsonConvert.SerializeObject(this.BairristaMenssage, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });

                //return JsonConvert.SerializeObject(this.BairristaError);
            }
            catch
            {
                return "";
            }
        }
    }

    public enum ExceptionEnum
    {
        NotFound = 404,
        BadRequest = 400,
        Unauthorized = 401,
        InternalServerError = 500,
    }

    public class BairristaMenssage
    {
        [JsonProperty("codigo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Codigo { get; set; } = "";

        [JsonProperty("messagem", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Messagem { get; set; } = "";

        [JsonProperty("erros", DefaultValueHandling = DefaultValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Error)]
        public List<BairristaError> Erros { get; set; }

        [JsonProperty("reference", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public object Reference { get; set; }
    }

    public class BairristaError
    {
        [JsonProperty("codigo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Codigo { get; set; } = "";

        [JsonProperty("messagem", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Messagem { get; set; } = "";

        [JsonProperty("propriedade ", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Propriedade { get; set; } = "";
    }
}
