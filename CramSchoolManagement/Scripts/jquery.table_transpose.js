(function(jQuery) {
    jQuery.fn.table_transpose = function (){
		tid = "#"+jQuery(this).attr("id");
		jQuery(tid+" tr").addClass("temptr");
		jQuery(tid+" thead,"+tid+" tbody").children().unwrap();
		jQuery(tid+" tr:first td,"+tid+" tr:first th").each(function(){
			tds = jQuery(this).index()+1;
			jQuery(tid).append("<tr />");
			jQuery(tid+" tr.temptr").each(function(){
				jQuery(tid+" tr:eq("+jQuery(this).index()+") > :nth-child("+tds+")").clone(true).appendTo(tid+" tr:last");
			});
		});
		jQuery(tid+" tr.temptr").remove();
		return this;
		}
})(jQuery);
