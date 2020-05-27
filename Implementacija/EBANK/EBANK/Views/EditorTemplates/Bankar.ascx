<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EBANK.Models.Bankar>" %>

<%: Html.LabelFor(bankar => bankar.Ime) %> <br />
<%: Html.TextBoxFor(bankar => bankar.Ime) %> <br />
<%: Html.LabelFor(bankar => bankar.Prezime) %> <br />
<%: Html.TextBoxFor(bankar => bankar.Prezime) %> <br />
<%: Html.LabelFor(bankar => bankar.KorisnickoIme) %> <br />
<%: Html.TextBoxFor(bankar => bankar.KorisnickoIme) %> <br />
<%: Html.LabelFor(bankar => bankar.Lozinka) %> <br />
<%: Html.TextBoxFor(bankar => bankar.Lozinka) %> <br />
Address <br />
<%: Html.LabelFor(bankar => bankar.MjestoZaposlenja.Latitude) %> <br />
<%: Html.TextBoxFor(bankar => bankar.MjestoZaposlenja.Latitude) %> <br />
<%: Html.LabelFor(bankar => bankar.MjestoZaposlenja.Longitude) %> <br />
<%: Html.TextBoxFor(bankar => bankar.MjestoZaposlenja.Longitude) %> <br />
<%: Html.LabelFor(bankar => bankar.MjestoZaposlenja.Naziv) %> <br />
<%: Html.TextBoxFor(bankar => bankar.MjestoZaposlenja.Naziv) %> <br />