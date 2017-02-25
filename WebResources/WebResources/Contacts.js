var Contacts = (function () {
    //Private properties & methods

    //var x = 0;
    //var _privateMethod = function() {
    //    return x++;
    //};

    //Public 
    return {
        hello: function () {
            alert("Hello, Code Camp!");
        },
        logField: function (fieldName) {
            console.log(fieldName);
            if (Xrm.Page.getAttribute(fieldName) != null) {
                console.log(Xrm.Page.getAttribute(fieldName).getValue());
            }
            else
            {
                alert("Form is expecting field: " + fieldName);

            }
        },
        logDirty: function ()
        {
            alert(Xrm.Page.data.entity.getDataXml());
            
         
        }
    };
})();