dsiPDCXListener.CSharp
==========

* More documentation?  http://developer.mercurypay.com
* Questions?  integrationteam@mercurypay.com
* **Feature request?** Open an issue.
* Feel like **contributing**?  Submit a pull request.


##Overview

This repository demonstrates how to interact with locally installed peripherals while hosting your POS application in the cloud.  There are two key attributes that facilitate this SaaS model:

* The dsiPDCXListener&trade; provides the ability to send http commands that drive peripheral devices.
* JavaScript that makes the http calls to the dsiPDCXListener&trade; from the client's web browser.

##Prerequisites

Please contact your Developer Integrations Analyst for any questions about the below prerequisites.

* dsiPDCXListener&trade; installed and running
* IPTranLT&trade; Mobile -- this is a hardware device to which hardware peripherals can/will attach.
* A cash drawer, receipt printer, and peripheral device that will all attach to the IPTranLT&trade; Mobile.
* The code will also work with the dsiPDCXListener&trade; and a hardware device attached directly to the computer so if you do not have the IPTranLT&trade; Mobile and other hardware devices (cash drawer, receipt printer, etc.) you will still be able to see the functionality.

##Example Site

An example site is hosted here:  <a href="http://durangopizza.azurewebsites.net" target="_blank">Durango Pizza Azure Website</a>

This site demonstrates the use of two DataCap Systems Inc. technologies:  the dsiPDCXListener&trade; and the IPTranLT&trade; Mobile.  Visit the site using your favorite web browser and then click the 'Admin' link.  Enter the IP address and port where the dsiPDCXListener&trade; is running and then enter your TranDeviceID that you will find on the IPTranLT&trade; Mobile device.  Finally press the 'Update' button and then purchase some pizza.  The JavaScript will execute driving the pole display, peripheral device, receipt printer, and cash drawer for a full integrated payment experience.

As an alternative you can modify the other fields on the Admin page to allow this example to work with the dsiPDCXListener&trade; and a hardware device attached directly to the computer.

The Azure website is active for 15 minutes and then after 15 minutes of no activity it will recycle and reset the Admin settings back to the default.

##Step 1: Display a payment page

These steps show the generic path to processing transactions using the durangopizza.azurewebsites.net site as an example.

In our case the payment page is fairly simple.  It contains an amount text box, an option for credit or debit, and a submit button.

```
<form id="purchaseform" action="" method="post">
    <p>
        <label>Amount:</label><input type="text" id="amount" name="amount" value="1.22" /><br />
        <input type="radio" name="trantype" value="Debit" checked />Debit
        <br />
        <input type="radio" name="trantype" value="Credit" />Credit
        <br />
        <input type="submit" value="Pay" />
    </p>
</form>
```

##Step 2:Capture submit event and POST to dsiPDCXListener

When the user presses the 'Pay' button above we capture the event in JavaScript and initiate the process of sending transactions by posting to the dsiPDCXListener&trade; via JavaScript.  You will see in the code (the Pizza.cshtml page) that the process function kicks off the process and a context object provides state data for all of the JavaScript functions.  The postData function is actually where the data is posted to the dsiPDCXListener&trade;.

You can see below that the url is included in the context object as is the actual data to post.  The data is configurable on the hosted (server) side and then written to the context object at runtime.

```
function postData(context) {
  var posting = $.ajax({
    type: "POST",
    url: context.url,
    data: context.data,
    contentType: context.contentType,
  });

  posting.done(function (data) {
    context.returnData = data;
    process(context);
  });

  posting.error(function (xhr, textStatus, errorThrown) {
    alert(xhr.responseText);
  });
}
```

The data that is POSTed to the dsiPDCXListener&trade; is familiar XML with a few modifications.  The XML below is used to write to the PoleDisplay.  The {0} is filled in at runtime by the TranDeviceID configured in the Admin screen mentioned above.  The {1} is filled in at runtime with the list of data to write to the PoleDisplay and looks like:  <Line1>.Write to Pole Display</Line1>.  You can write multiple lines to the PoleDisplay via additional <Line#> elements.

```
<?xml version=\"1.0\"?>
  <TStream>
    <Admin>
      <TranDeviceID>{0}</TranDeviceID>
      <TranCode>PoleDisplay</TranCode>
      <MerchantID>494901</MerchantID>
      <ComPort>0</ComPort>
      <SecureDevice>ONTRAN</SecureDevice>
      {1}
    </Admin>
  </TStream>
```

##Step 3: Parse Response

The parsing mechanism will change depending on which dsiPDCXListener&trade; method you use.  There are four differnt methods supported by the dsiPDCXListener&trade; (method1, method2, method3, method4 -- these are the actual names) for more information about the different methods please refer to the integration guide.  For example if you are using method1 that means you are sending/receiving XML and therefore you will need to send and parse XML.  Here's sample JavaScript that shows parsing the response returned by the dsiPDCXListener&trade; into the context JavaScript object.

```
    function parseXmlFromDataCapXML(context) {

        xmlDoc = $.parseXML(context.returnData);
        $xml = $(xmlDoc);
        
        context.AuthCode = $xml.find('AuthCode').text();
        context.ResponseOrigin = $xml.find('ResponseOrigin').text();
        context.DSIXReturnCode = $xml.find('DSIXReturnCode').text();
        context.CmdStatus = $xml.find('CmdStatus').text();
        context.TextResponse = $xml.find('TextResponse').text();
        context.MerchantID = $xml.find('MerchantID').text();
        context.AcctNo = $xml.find('AcctNo').text();
        context.TranCode = $xml.find('TranCode').text();
        context.CaptureStatus = $xml.find('CaptureStatus').text();
        context.InvoiceNo = $xml.find('InvoiceNo').text();
        context.Purchase = $xml.find('Purchase').text();
        context.Authorize = $xml.find('Authorize').text();
        context.RecordNo = $xml.find('RecordNo').text();

        return context;
    }
```

###©2014 Mercury Payment Systems, LLC - all rights reserved.

Disclaimer:
This software and all specifications and documentation contained herein or provided to you hereunder (the "Software") are provided free of charge strictly on an "AS IS" basis. No representations or warranties are expressed or implied, including, but not limited to, warranties of suitability, quality, merchantability, or fitness for a particular purpose (irrespective of any course of dealing, custom or usage of trade), and all such warranties are expressly and specifically disclaimed. Mercury Payment Systems shall have no liability or responsibility to you nor any other person or entity with respect to any liability, loss, or damage, including lost profits whether foreseeable or not, or other obligation for any cause whatsoever, caused or alleged to be caused directly or indirectly by the Software. Use of the Software signifies agreement with this disclaimer notice.

