namespace slothlandapi.Response
{
	public class ResponseAPI<T>
	{
		public bool Success { get; set; } = true;
		public T? DataResponse { get; set; }
		public string? Message { get; set; }
		public string? DataError { get; set; }

	}
}
