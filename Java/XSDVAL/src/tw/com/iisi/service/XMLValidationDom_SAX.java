package tw.com.iisi.service;

import java.io.IOException;
import java.util.LinkedList;
import java.util.List;

import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;
import javax.xml.transform.Source;
import javax.xml.transform.stream.StreamSource;
import javax.xml.validation.SchemaFactory;

import org.apache.log4j.Logger;
import org.xml.sax.ErrorHandler;
import org.xml.sax.InputSource;
import org.xml.sax.SAXException;
import org.xml.sax.SAXParseException;
import org.xml.sax.XMLReader;

public class XMLValidationDom_SAX {
	private static String xsdPath;
	private static Logger log;
	private String ErrorMessage;

	public XMLValidationDom_SAX() {
		xsdPath = "";
		log = Logger.getLogger("parse");
	}

	public void setxsdPath(String xsdPath) {
		this.xsdPath = xsdPath;
	}

	public static void validateXMLSchema(String xmlPath) {

		SAXParserFactory factory = SAXParserFactory.newInstance();

		factory.setValidating(false);
		factory.setNamespaceAware(true);

		SchemaFactory schemaFactory = SchemaFactory.newInstance("http://www.w3.org/2001/XMLSchema");

		try {
			factory.setSchema(schemaFactory.newSchema(new Source[] { new StreamSource(xsdPath) }));
			//建立一個SAX XML驗證器
			SAXParser parser = factory.newSAXParser();
			
			XMLReader reader = parser.getXMLReader();
			
			//所有的exception訊息
			final List<String> exceptions = new LinkedList<String>();
			reader.setErrorHandler(new ErrorHandler() {
				@Override
				public void warning(SAXParseException exception) throws SAXException {
					String str = new StringBuffer("分析發生一般錯誤：\n")
							.append("Error Line: " + exception.getLineNumber() + "\n")
							.append("Error Column: " + exception.getColumnNumber() + "\n")
							.append("Error Message: " + exception.getMessage()+ "\n").toString();
					exceptions.add(str);
				}

				@Override
				public void fatalError(SAXParseException exception) throws SAXException {
					String str = new StringBuffer("分析發生重大錯誤：")
							.append("Error Line: " + exception.getLineNumber() + "\n")
							.append("Error Column: " + exception.getColumnNumber() + "\n")
							.append("Error Message: " + exception.getMessage()+ "\n").toString();
					exceptions.add(str);
				}

				@Override
				public void error(SAXParseException exception) throws SAXException {
					String str = new StringBuffer("分析發生警告：\n")
							.append("Error Line: " + exception.getLineNumber() + "\n")
							.append("Error Column: " + exception.getColumnNumber() + "\n")
							.append("Error Message: " + exception.getMessage()+ "\n").toString();
					exceptions.add(str);
				}

			});
			
			//開始驗證XML
			reader.parse(new InputSource(xmlPath));
			
			if (exceptions.isEmpty())
				System.out.println("檢核完成，符合xsd規則");
			else {
				for (String eachexception : exceptions) {
				System.out.println(eachexception);
				}
			}
			
		} catch (SAXException e) {
			String str = new StringBuffer("SAXException：").append(e.getMessage()).toString();
			log.error(str);
		} catch (ParserConfigurationException e) {
			String str = new StringBuffer("ParserConfigurationException：").append(e.getMessage()).toString();
			log.error(str);
		} catch (IOException e) {
			String str = new StringBuffer("IOException：").append(e.getMessage()).toString();
			log.error(str);
		}

	}

}
