function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function makeClick(campaignId) {
    var affId = getParameterByName("affId");

    if (affId) {
        var xhr = new XMLHttpRequest();
        xhr.open(
            "GET",
            "http://localhost:11784/clicks/registerclick?affId=" + affId + "&campaignid=" + campaignId,
            true);
        xhr.send();
    }
}