

@extends('layouts.default')


@section('content')
<div class="jumbotron">
				<h2>Εορτολόγιο</h2>
				{{Form::open()}}
				{{Form::label('days','Ημερομηνία')}}
				{{Form::input('date','days')}}
				{{Form::close()}}
			</div>

<div id="test">
	sadadasd
</div>

<script>
$(document).ready(function(){

	$('#days').click(function(){
		var d = $('#days').val();
		d = d.split('-');

		if(d[1]!=10) d[1] = d[1].replace("0", "");

		 $.ajax({
            type:"GET",
            url:"getEorti",
            data:{"day":d[2],"month":d[1]},
            success:function(data){
           // var b = jQuery.parseJSON(data)
           // for(var i=0;i<Object.keys(b).length;i++){
           // $( "#test" ).append( b[i].Onoma+'</br>' );
      //  }      
            console.log(data);    	
        }            
        });
	});

});
</script>


@stop


