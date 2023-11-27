var currentBookId;

// hides the modal popup
function closeBookDetailsModal() {
    $('#bookDetailsModal').modal('hide');
}

// opens the modal and populates the data to be shows in the product details popup
function showBookDetails(id, title, price, description, image, stock, author) {
    // Store the current bookId
    currentBookId = id;

    // Setting the modal content with the book details
    $('#bookDetailsModalTitle').text(title);
    $('#bookDetailsModalPrice').text('Price: Rs.' + price);
    $('#bookDetailsModalAuthor').text('Author: ' + author);
    $('#bookDetailsModalDescription').text(description);
    $('#bookDetailsModalImage').attr('src', 'assets/images/books/' + image);

    // Showing the "Out Of Stock" badge and conditionally disable the "Add to Cart" button
    if (stock == 0) {
        $('#bookDetailsModalOutOfStock').show();
        $('#bookDetailsModalAddToCart').prop('disabled', true);
    } else {
        $('#bookDetailsModalOutOfStock').hide();
        $('#bookDetailsModalAddToCart').prop('disabled', false);
    }

    // Showing the modal
    $('#bookDetailsModal').modal('show');
}

// adding books to the cart
function addToCart(bookId) {
    // Making an AJAX request
    $.ajax({
        url: '/Cart/AddToCart',
        type: 'POST',
        data: { bookId: bookId },

        success: function (response) {
            location.reload();
        },

    });
}

// Function to add the book to the cart from the modal
function addToCartFromModal() {
    // Make an AJAX request to add the book to the cart
    $.ajax({
        url: '/Cart/AddToCart', 
        type: 'POST',
        data: { bookId: currentBookId },
        success: function (response) {
            location.reload();
        },
    });
}
