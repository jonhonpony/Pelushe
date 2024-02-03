<script>
    function toggleSubcategories(categoryId) {
        var subcategories = document.getElementById('subcategories_' + categoryId);
    if (subcategories.style.display === 'none' || subcategories.style.display === '') {
        subcategories.style.display = 'block'};
        } else {
        subcategories.style.display = 'none'};
        }
    }
</script>

