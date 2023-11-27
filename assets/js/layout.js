function toggleDrawer() {
    $("#cartDrawer").toggleClass("drawer-open");
}

$(document).ready(function () {
    // Click event for the cart button
    $("#cartButton").click(function (e) {
        // Prevent default behavior (e.g., navigating to a link)
        e.preventDefault();

        // Toggle the drawer
        toggleDrawer();
    });

    // Close the drawer when clicking outside
    $(document).mouseup(function (e) {
        var container = $("#cartDrawer");
        if (!container.is(e.target) && container.has(e.target).length === 0) {
            container.removeClass("drawer-open");
        }
    });

});

function removeFromCart(bookId) {
    // Make AJAX request to remove the item
    $.ajax({
        url: '/Cart/RemoveItem',
        type: 'POST',
        data: { bookId: bookId },
        success: function (response) {
            location.reload();
        },
    });
}

function checkout() {
    window.location.href = '/Checkout/Index';
}

function closeCartDrawer() {
    
    var container = $("#cartDrawer");
    container.removeClass("drawer-open");
}