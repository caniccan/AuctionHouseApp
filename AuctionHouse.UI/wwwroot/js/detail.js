
let connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:8001/auctionhub").build();
let auctionId = document.getElementById("AuctionId").value;

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

let groupName = "auction-" + auctionId;

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
    connection.invoke("AddToGroup", groupName).catch(function (err) {
        return console.error();
    });
}).catch(function (err) {
    return console.error();
});

connection.on("Bids", function (user, bid) {
    addBidToTable(user, bid);
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    let user = document.getElementById("SellerUserName").value;
    let productId = document.getElementById("ProductId").value;
    let sellerUser = user;
    let bid = document.getElementById("PriceInput").value;

    let sendBidRequest = {
        AuctionId: auctionId,
        ProductId: productId,
        SellerUserName: sellerUser,
        Price: parseFloat(bid).toString()
    }
    SendBid(sendBidRequest);
    event.preventDefault();
});

document.getElementById("finishButton").addEventListener("click", function (event) {

    let sendCompleteBidRequest = {
        Id: auctionId,
    }
    SendCompleteBid(sendCompleteBidRequest);
    event.preventDefault();
});

function addBidToTable(user, bid) {
    var str = "<tr>";
    str += "<td>" + user + "</td>";
    str += "<td>" + bid + "</td>";
    str += "</tr>";

    if ($('table > tbody> tr:first').length > 0) {
        $('table > tbody> tr:first').before(str);
    } else {
        $('.bidLine').append(str);
    }

}

function SendBid(model) {
    $.ajax({

        url: "/Auction/SendBid",
        type: "POST",
        data: model,
        success: function (response) {
            if (response.isSuccess) {
                document.getElementById("PriceInput").value = "";
                connection.invoke("SendBidAsync", groupName, model.SellerUserName, model.Price).catch(function (err) {
                    return console.error();
                });
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
}

function SendCompleteBid(model) {
    $.ajax({

        url: "/Auction/CompleteBid",
        type: "POST",
        data: model,
        success: function (response) {
            if (response.isSuccess) {
                console.log("Your auction has been successfully completed.")
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
}