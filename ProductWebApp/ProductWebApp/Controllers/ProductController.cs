using System.Collections.Generic;
using System.Web.Http;
using System;
using System.Net;
using System.Net.Http;
using ProductWebApp.Business;
using ProductWebApp.Entities.Models;
using Newtonsoft.Json;
using System.Text;

namespace ProductWebApp.Controllers
{
    [RoutePrefix("api/v1/products")]
    public class ProductController : ApiController
    {
        CommentManager commentManager = new CommentManager();
        ProductManager productManager = new ProductManager();

    
   
        [Route("productlist")]
        public HttpResponseMessage GetAllProducts()
        {
            try
            {               
                return Request.CreateResponse(HttpStatusCode.OK, productManager.GetAllProducts());
            }
            catch (Exception ex)
            {
                var message = string.Format("Error occured" + ex);
                HttpError error = new HttpError(message);
                var json = JsonConvert.SerializeObject(error, Formatting.Indented);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, json);
            }
        }
        [Route("product")]
        public HttpResponseMessage GetProduct(int productId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(productManager.GetProducts(productId), Formatting.Indented));
            }
            catch (Exception ex)
            {
                var message = string.Format("Error occured" + ex);
                HttpError error = new HttpError(message);
                var json = JsonConvert.SerializeObject(error, Formatting.Indented);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, json);
            }
        }

        [HttpPost]
        [Route("addproducttest")]
        public HttpResponseMessage JsonStringBody(HttpRequestMessage httpRequest)
        {
           var httpRequestBody = httpRequest.Content.ReadAsStringAsync().Result;
            if (httpRequestBody == null)
            {
                var message = string.Format("Bad Request null data passed.");
                HttpError error = new HttpError(message);
                var json = JsonConvert.SerializeObject(error, Formatting.Indented);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, json);
            }
            else {
                
               // var productjson = Encoding.UTF8.GetString(Convert.FromBase64String(httpRequestBody));
               return Request.CreateResponse(HttpStatusCode.OK, httpRequestBody); 
            }
        }
        [HttpPost]
        [Route("addproduct")]
        public HttpResponseMessage AddProduct([FromBody] Product product)
        {
            try
            {
              return Request.CreateResponse(HttpStatusCode.OK, productManager.AddProduct(product));
            }
            catch (Exception ex)
            {
                var message = string.Format("Error occured" + ex);
                HttpError error = new HttpError(message);
                var json = JsonConvert.SerializeObject(error, Formatting.Indented);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, json);
            }
        }
        [Route("editproduct")]
        public HttpResponseMessage UpdateProduct([FromBody] Product product)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, productManager.UpdateProduct(product));
            }
            catch (Exception ex)
            {
                var message = string.Format("Error occured" + ex);
                HttpError error = new HttpError(message);
                var json = JsonConvert.SerializeObject(error, Formatting.Indented);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, json);
            }
        }


        [Route("addbulkproduct")]
        public HttpResponseMessage AddBulkProduct([FromBody] IEnumerable<Product> products)
        {
            try
            {
                productManager.AddBulkProduct(products);
                return Request.CreateResponse(HttpStatusCode.OK, "Passed");
            }
            catch (Exception ex)
            {
                var message = string.Format("Error occured" + ex);
                HttpError error = new HttpError(message);
                var json = JsonConvert.SerializeObject(error, Formatting.Indented);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, json);
            }
        }

        [Route("deleteproduct")]
        public HttpResponseMessage DeleteProduct([FromBody] Product product)
        {
            try
            {
                productManager.DeleteProduct(product);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                var message = string.Format("Error occured" + ex);
                HttpError error = new HttpError(message);
                var json = JsonConvert.SerializeObject(error, Formatting.Indented);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, json);
            }
        }


        [Route("addcomment")]
        public HttpResponseMessage AddComment([FromBody] Comment comment)
        {
            try
            {
                commentManager.AddComment(comment);
                return Request.CreateResponse(HttpStatusCode.OK, "Passed");
            }
            catch (Exception ex)
            {
                var message = string.Format("Error occured" + ex);
                HttpError error = new HttpError(message);
                var json = JsonConvert.SerializeObject(error, Formatting.Indented);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, json);
            }
        }

        [Route("comment")]
        public HttpResponseMessage GetComment(int productId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, commentManager.GetComments(productId));
            }
            catch (Exception ex)
            {
                var message = string.Format("Error occured" + ex);
                HttpError error = new HttpError(message);
                var json = JsonConvert.SerializeObject(error, Formatting.Indented);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, json);
            }
        }

        [Route("countproduct")]
        public HttpResponseMessage GetProductNumber()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, productManager.GetProductNumber());
            }
            catch (Exception ex)
            {
                var message = string.Format("Error occured" + ex);
                HttpError error = new HttpError(message);
                var json = JsonConvert.SerializeObject(error, Formatting.Indented);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, json);
            }
        }
    }
}
