using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace MovieShop.MVC.Utils
{
	public class EmailInform
	{
		public void Send()
		{
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Grace Liu", "guirong.liu18@gmail.com"));
			message.To.Add(new MailboxAddress("Grace", "guirong.liu18@gmail.com"));
			message.Subject = "Error occured on your website";

			message.Body = new TextPart("plain")
			{
				Text = @"Hey developer,

						An error has occured on your website, please fix it soon.

						-- Joey"
			};

			using (var client = new SmtpClient())
			{
				client.Connect("smtp.gmail.com", 587, false);
				client.AuthenticationMechanisms.Remove("XOAUTH2");

				// Note: only needed if the SMTP server requires authentication
				client.Authenticate("mail_address", "password");

				client.Send(message);
				client.Disconnect(true);
			}
		}
	}
}