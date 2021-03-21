using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ReportFromXmlAndTxt.Models
{
	[XmlRoot(ElementName = "TransmitterErrorDetailGrp", Namespace = "urn:us:gov:treasury:irs:ext:aca:air:ty20")]
	public class TransmitterErrorDetailGrp
	{
		[XmlElement(ElementName = "SubmissionLevelStatusCd", Namespace = "urn:us:gov:treasury:irs:ext:aca:air:ty20")]
		public string SubmissionLevelStatusCd { get; set; }
		[XmlElement(ElementName = "UniqueSubmissionId", Namespace = "urn:us:gov:treasury:irs:ext:aca:air:ty20")]
		public string UniqueSubmissionId { get; set; }
		[XmlElement(ElementName = "UniqueRecordId", Namespace = "urn:us:gov:treasury:irs:ext:aca:air:ty20")]
		public string UniqueRecordId { get; set; }
		[XmlElement(ElementName = "ErrorMessageDetail", Namespace = "urn:us:gov:treasury:irs:common")]
		public ErrorMessageDetail ErrorMessageDetail { get; set; }
	}

	[XmlRoot(ElementName = "ErrorMessageDetail", Namespace = "urn:us:gov:treasury:irs:common")]
	public class ErrorMessageDetail
	{
		[XmlElement(ElementName = "ErrorMessageCd", Namespace = "urn:us:gov:treasury:irs:common")]
		public string ErrorMessageCd { get; set; }
		[XmlElement(ElementName = "ErrorMessageTxt", Namespace = "urn:us:gov:treasury:irs:common")]
		public string ErrorMessageTxt { get; set; }
		[XmlElement(ElementName = "XpathContent", Namespace = "urn:us:gov:treasury:irs:common")]
		public string XpathContent { get; set; }
	}

	[XmlRoot(ElementName = "ACATransmitterSubmissionDetail", Namespace = "urn:us:gov:treasury:irs:ext:aca:air:ty20")]
	public class ACATransmitterSubmissionDetail
	{
		[XmlElement(ElementName = "TransmitterErrorDetailGrp", Namespace = "urn:us:gov:treasury:irs:ext:aca:air:ty20")]
		public List<TransmitterErrorDetailGrp> TransmitterErrorDetailGrp { get; set; }
	}

	[XmlRoot(ElementName = "FormBCTransmitterSubmissionDtl", Namespace = "urn:us:gov:treasury:irs:msg:form1094-1095BCtransmittermessage")]
	public class FormBCTransmitterSubmissionDtl
	{
		[XmlElement(ElementName = "ACATransmitterSubmissionDetail", Namespace = "urn:us:gov:treasury:irs:ext:aca:air:ty20")]
		public ACATransmitterSubmissionDetail ACATransmitterSubmissionDetail { get; set; }
		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }
		[XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns2 { get; set; }
		[XmlAttribute(AttributeName = "ns3", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns3 { get; set; }
	}


}
