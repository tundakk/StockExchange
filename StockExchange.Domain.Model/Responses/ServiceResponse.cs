namespace StockExchange.Domain.Model.Responses
{
    /// <summary>
    /// This class wraps the object in a property called Data. it has Success and Message as other properties, that is used to send back if the Data property has data in it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T>
    {
        public T? Data { get; set; } // placeholder type 
        public bool Success { get; set; } = true; //this property and Message is used to give tell if data is null and what reason it could be. if/else statement
        public string Message { get; set; } = string.Empty;
    }
}
