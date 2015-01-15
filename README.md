dsiPDCXListener.CSharp
==========

##Overview

This repository demonstrates the ability to interact with local peripherals while hosting your POS application in the cloud.  There are two "tricks":

* dsiPDCXListener which provides the ability to send http commands that drive peripheral devices
* A little bit of javascript that makes the http calls to the dsiPDCXListener

An example site is hosted here:  durangopizza.azurewebsites.net.  This site demonstrates the use of two DataCap technologies:  the dsiPDCXListener and the IPTranLT Mobile.  Visit the site using your favorite web browser and then click the 'Admin' link.  Enter the IP address and port where the dsiPDCXListener is running and then enter your TranDeviceID that you will find on the IPTranLT Mobile.  Finally press the 'Update' button and then purchase some pizza.  The javascript will execute driving the pole display, peripheral device, receipt printer, and cash drawer for a full integrated payment experience.

##Prerequisites

* dsiPDCXListener installed and running -- you can obtain this software from your DataCap representative
* IPTranLT Mobile -- this is a hardware device you can also obtain from your DataCap representative.  With a few tweaks this example could also run without the IPTranLT Mobile.
* A cash drawer, receipt printer, and peripheral device that will all attach to the IPTranLT Mobile.  As mentioned above with a few tweaks you could run this demo with only a peripheral device attached direclty to the computer with the dsiPDCXListener.

##Step 1: Display a payment page

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

When the user presses the 'Pay' button above we capture the event in javascript and initiate the process of sending transactions by posting to the dsiPDCXListener via javascript.  You will see in the code (the Pizza.cshtml page) that the process function kicks off the process and a context object provides state data for all of the javascript functions.  The postData function is actually where the data is posted to the dsiPDCXListener.

You can see below that the url is included in the context object as is the actual data to post.  That is so that everything is configurable, these values are written to the page when the server sends the page down to the client.

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

The data that is POSTed to the dsiPDCXListener is the familiar DataCap XML with a few modifications.  The XML below is used to write to the PoleDisplay.  The {0} is filled in at runtime by the TranDeviceID configured in the Admin screen mentioned above.  The {1} is filled in at runtime with the list of data to write to the PoleDisplay and looks like:  <Line1>.Write to Pole Display</Line1>.  You can write multiple lines to the PoleDisplay via additional <Line#> elements.

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

Depending on which dsiPDCXListener method you are POSTing to the parsing mechanism will change.  For example if you are using method1 that means you are sending/receiving DataCap XML and therefore you will need to send and parse DataCap XML.  Here's sample javascript that shows parsing the response returned by the dsiPDCXListener into the context javascript object.

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

