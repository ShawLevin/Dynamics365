var Accounts = function ()
{
    return {
        SetData: function ()
        {
            var name = <Xrm.Page.StringAttribute>Xrm.Page.data.entity.attributes.get("name");
            name.setValue("hey code camp");  
            return "Data";
        }
    }
}