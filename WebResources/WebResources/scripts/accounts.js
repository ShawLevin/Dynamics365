var Accounts = function () {
    return {
        SetData: function () {
            var name = Xrm.Page.data.entity.attributes.get("name");
            return "Data";
        }
    };
};
