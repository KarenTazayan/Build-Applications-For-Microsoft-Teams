namespace TabsAndPersonalPages.Models;

public class PersonalTab
{
	public PersonalTab(string message)
	{
		Message = message;
	}

	public string Message { get; set; }

	public string GetColor()
	{
		return Message;
	}
}