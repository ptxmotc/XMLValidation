package tw.com.iisi.main;

import tw.com.iisi.service.XMLValidationDom_SAX;

import java.io.File;
import java.io.IOException;

import java.util.Scanner;

public class Main {

	public static void main(String[] args) throws  IOException {

		XMLValidationDom_SAX XMLValDom = new XMLValidationDom_SAX();
		//xsd檔案來源位置
		String xsdsrc = "";
		//xml檔案來源位置
		String xmlsrc = "";
		Scanner scanner = new Scanner(System.in);
		//XML內容大小限制
		System.setProperty("jdk.xml.maxOccurLimit", "20000");
		System.out.println("加入xsd路徑");
		xsdsrc = scanner.next();
		XMLValDom.setxsdPath(xsdsrc);
		System.out.println("輸入所要檢查xml路徑");
		xmlsrc = scanner.next();
		XMLValDom.validateXMLSchema(xmlsrc);
		

	}



}