using DSharpPlus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stockapp
{


	public partial class Form2 : Form
	{
		static DiscordClient discord;

		public class Quote
		{
			public string symbol { get; set; }
			public DateTime date { get; set; }
			public decimal price { get; set; }
			public string type { get; set; }
		}
		public Quote q_td = new Quote();


		static async Task MainAsync(string[] args)
		{
			discord = new DiscordClient(new DiscordConfiguration
			{
				Token = "NzQ5NjYxOTgzNzA3NDk2NTE5.X0vPIA.RpyQUV5FuBE1gWUEf8R1KIgSgmg",
				TokenType = TokenType.Bot
			});

			discord.MessageCreated += async e =>
			{
				if (e.Message.Content.ToLower().StartsWith("ping"))
					await e.Message.RespondAsync("pong!");
			};

			await discord.ConnectAsync();
			await Task.Delay(-1);
		}

		public Form2()
		{
			//MainAsync(null).ConfigureAwait(false).GetAwaiter().GetResult();

			

			var str = "TSLA200710C1800";
			var rest = new string(str.SkipWhile(c => !char.IsDigit(c)).ToArray());
			var q = new Quote() { symbol = new string(str.TakeWhile(c => !char.IsDigit(c)).ToArray()) };
			var d = rest.Substring(0, 6);
			q.date = DateTime.ParseExact(d, "yyMMdd", CultureInfo.InvariantCulture);
			q.type = rest.Substring(6, 1);
			q.price = decimal.Parse(rest.Substring(7));

			InitializeComponent();
		}
		private string GetQuote(string s)
		{
			var d = s.Replace("$", "").Replace("C", "").Replace("P", "");
			return decimal.Parse(d).ToString("C2").Replace("$", "");
		}
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void printTos(Quote q)
		{
			//if (price.IndexOf(".") > 0)
				//price = price.Substring(0, price.IndexOf("."));
			tb_tos.Text = "." + q.symbol + q.date.ToString("yyMMdd") + q.type + q.price.ToString("G29");
			System.Windows.Forms.Clipboard.SetText(tb_tos.Text);
		}

		private void printIB(Quote q)
		{
			tb_ib.Text = q.symbol + " " + q.type + " " + q.date.ToString("ddMMMyy") + " " + q.price.ToString();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				var arr = tb_ib.Text.Split(' ');
				var date = DateTime.ParseExact(arr[1].Replace("'", " "), "MMMdd yy", CultureInfo.InvariantCulture);
				var q = new Quote() { symbol = arr[0], price = decimal.Parse(arr[2]), type = arr[3] == "Call" ? "C" : "P", date = date };
				tb_xtrade.Text = q.symbol + " " + q.type + " " + q.date.ToString("ddMMMyy") + " " + q.price.ToString();
				printTos(q);

			}
			catch (Exception ex)
			{
				MessageBox.Show("error");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				var input = tb_xtrade.Text.ToUpper();
				var arr = input.Split(' ');
				Quote q = new Quote();
				if (arr[1].EndsWith("C") || arr[1].EndsWith("P"))
				{
					var type = arr[1].EndsWith("C") ? "C" : "P";
					tb_td.Text = arr[0] + " C " + DateTime.Parse(arr[2]).ToString("ddMMMyy") + " " + GetQuote(arr[1]);
					q = new Quote() { date = DateTime.Parse(arr[2]), price = decimal.Parse(GetQuote(arr[1])), symbol = arr[0], type = type };
				}
				else
				{
					var type = arr[2].EndsWith("C") ? "C" : "P";

					tb_td.Text = arr[0] + $" {type} " + DateTime.Parse(arr[1]).ToString("ddMMMyy") + " " + GetQuote(arr[2]);
					q = new Quote() { date = DateTime.Parse(arr[1]), price = decimal.Parse(GetQuote(arr[2])), symbol = arr[0], type = type };
				}
				printTos(q);
			}
			catch (Exception ex)
			{
				tb_ib.Text = "error";
			}
		}

		private void PrintTD()
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				var input = tb_funtrade.Text.ToUpper();

				var str = input;
				var rest = new string(str.SkipWhile(c => !char.IsDigit(c)).ToArray());
				var q = new Quote() { symbol = new string(str.TakeWhile(c => !char.IsDigit(c)).ToArray()) };
				var d = rest.Substring(0, 6);
				q.date = DateTime.ParseExact(d, "yyMMdd", CultureInfo.InvariantCulture);
				q.type = rest.Substring(6, 1);
				q.price = decimal.Parse(rest.Substring(7));

				tb_ib.Text = q.symbol + " " + q.type + " " + q.date.ToString("ddMMMyy") + " " + q.price.ToString();
				printTos(q);
			}
			catch (Exception ex)
			{
				tb_ib.Text = "error";
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			//BTO MRK Aug 21 2020 85 Call @ 0.48

			try
			{
				var q = new Quote();
				var input = "BTO " + tb_algo.Text.ToUpper();
				
				var arr = input.Split(' ');
				q.price = decimal.Parse(arr[5].Replace("$", ""));
				q.symbol = arr[1];
				q.type = arr[6] == "CALL" ? "C" : "P";
				q.date = DateTime.Parse(string.Format($"{arr[2]} {arr[3]} {arr[4]}"));
				//q.date = DateTime.ParseExact(string.Format($"{arr[2]} {arr[3]} {arr[4]}"), "MMMdd yy", CultureInfo.InvariantCulture);q.

				tb_xtrade.Text = q.symbol + " " + q.type + " " + q.date.ToString("ddMMMyy") + " " + q.price.ToString();
				printTos(q);
				
			}
			catch (Exception ex)
			{
				tb_ib.Text = "error";
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			//
			var perc = (decimal.Parse(txt_sell.Text) - decimal.Parse(txt_buy.Text)) / decimal.Parse(txt_buy.Text);
			var principal = decimal.Parse(txt_principal.Text);

			lbl_result.Text = $"{principal * (perc)} ({ (perc * 100).ToString() }%)";

		}

		private void button6_Click(object sender, EventArgs e)
		{
			try
			{
				var q = new Quote();
				var input = tb_td.Text.ToUpper();

				var arr = input.Split(' ');
				q.price = decimal.Parse(arr[3]);
				q.symbol = arr[0];
				q.type = arr[1];
				q.date = DateTime.Parse(arr[2]);
				printTos(q);
				printIB(q);
			} catch (Exception ex)
			{
				MessageBox.Show("error");
			}
		}
	}
}
