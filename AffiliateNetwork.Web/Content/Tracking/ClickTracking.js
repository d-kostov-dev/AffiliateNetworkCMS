function makeClick(affId, campaignId) {
    var xhr = new XMLHttpRequest();
    xhr.open(
        "GET",
        "http://localhost:11784/click/registerclick?affId=" + affId + "&campaignid=" + campaignId,
        true);
    xhr.send();
}

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}