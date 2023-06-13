using AdaptiveCards;
using MessageExtensions.App.Model;
using Microsoft.Bot.Schema.Teams;

namespace MessageExtensions.App.Helpers;

public class CardHelper
{
	public static List<MessagingExtensionAttachment> CreateAdaptiveCardAttachment(
		MessagingExtensionAction action, CardResponse createCardResponse)
	{
		var adaptiveCard = new AdaptiveCard(new AdaptiveSchemaVersion(1, 0))
		{
			Body = new List<AdaptiveElement>()
			{
				new AdaptiveColumnSet()
				{
					Columns = new List<AdaptiveColumn>()
					{
						new AdaptiveColumn()
						{
							Items=new List<AdaptiveElement>()
							{
								new AdaptiveTextBlock()
								{
									Text= "Name :",
									Wrap=true,
									Size=AdaptiveTextSize.Medium,
									Weight=AdaptiveTextWeight.Bolder
								}
							},
							Width = AdaptiveColumnWidth.Auto
						},
						new AdaptiveColumn()
						{
							Items=new List<AdaptiveElement>()
							{
								new AdaptiveTextBlock()
								{
									Text= createCardResponse.Title,
									Wrap=true,
									Size=AdaptiveTextSize.Medium,
								}
							},
							Width = AdaptiveColumnWidth.Auto
						},
					}
				},
				new AdaptiveColumnSet()
				{
					Columns = new List<AdaptiveColumn>()
					{
						new AdaptiveColumn()
						{
							Items=new List<AdaptiveElement>()
							{
								new AdaptiveTextBlock()
								{
									Text= "Designation :",
									Wrap=true,
									Size=AdaptiveTextSize.Medium,
									Weight=AdaptiveTextWeight.Bolder
								}
							},
							Width = AdaptiveColumnWidth.Auto
						},
						new AdaptiveColumn()
						{
							Items=new List<AdaptiveElement>()
							{
								new AdaptiveTextBlock()
								{
									Text= createCardResponse.Subtitle,
									Wrap=true,
									Size=AdaptiveTextSize.Medium,
								}
							},
							Width = AdaptiveColumnWidth.Auto
						},
					}
				},
				new AdaptiveColumnSet()
				{
					Columns = new List<AdaptiveColumn>()
					{
						new AdaptiveColumn()
						{
							Items=new List<AdaptiveElement>()
							{
								new AdaptiveTextBlock()
								{
									Text= "Description :",
									Wrap=true,
									Size=AdaptiveTextSize.Medium,
									Weight=AdaptiveTextWeight.Bolder
								}
							},
							Width = AdaptiveColumnWidth.Auto
						},
						new AdaptiveColumn()
						{
							Items=new List<AdaptiveElement>()
							{
								new AdaptiveTextBlock()
								{
									Text= createCardResponse.Text,
									Wrap=true,
									Size=AdaptiveTextSize.Medium,
								}
							},
							Width = AdaptiveColumnWidth.Auto
						},
					}
				},
			}
		};

		var attachments = new List<MessagingExtensionAttachment>
		{
			new MessagingExtensionAttachment
			{
				Content = adaptiveCard,
				ContentType = AdaptiveCard.ContentType
			}
		};

		return attachments;
	}

	public static List<MessagingExtensionAttachment> CreateAdaptiveCardAttachmentForHtml(
		MessagingExtensionAction action, CardResponse createCardResponse)
	{
		var adaptiveCard = new AdaptiveCard(new AdaptiveSchemaVersion(1, 0))
		{
			Body = new List<AdaptiveElement>()
			{
				new AdaptiveColumnSet()
				{
					Columns = new List<AdaptiveColumn>()
					{
						new AdaptiveColumn()
						{
							Items=new List<AdaptiveElement>()
							{
								new AdaptiveTextBlock()
								{
									Text= "User Name :",
									Wrap=true,
									Size=AdaptiveTextSize.Medium,
									Weight=AdaptiveTextWeight.Bolder
								}
							},
							Width = AdaptiveColumnWidth.Auto
						},
						new AdaptiveColumn()
						{
							Items=new List<AdaptiveElement>()
							{
								new AdaptiveTextBlock()
								{
									Text= createCardResponse.UserName,
									Wrap=true,
									Size=AdaptiveTextSize.Medium,
								}
							},
							Width = AdaptiveColumnWidth.Auto
						},
					}
				},
				new AdaptiveColumnSet()
				{
					Columns = new List<AdaptiveColumn>()
					{
						new AdaptiveColumn()
						{
							Items=new List<AdaptiveElement>()
							{
								new AdaptiveTextBlock()
								{
									Text= "Password is :",
									Wrap=true,
									Size=AdaptiveTextSize.Medium,
									Weight=AdaptiveTextWeight.Bolder
								}
							},
							Width = AdaptiveColumnWidth.Auto
						},
						new AdaptiveColumn()
						{
							Items=new List<AdaptiveElement>()
							{
								new AdaptiveTextBlock()
								{
									Text= createCardResponse.UserPwd,
									Wrap=true,
									Size=AdaptiveTextSize.Medium,
								}
							},
							Width = AdaptiveColumnWidth.Auto
						},
					}
				},
			}
		};

		var attachments = new List<MessagingExtensionAttachment>
		{
			new MessagingExtensionAttachment
			{
				Content = adaptiveCard,
				ContentType = AdaptiveCard.ContentType
			}
		};

		return attachments;
	}
}