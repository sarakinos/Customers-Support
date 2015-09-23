

@extends('layouts.default')


@section('content')
<div class="jumbotron">
				<h2>Διαχείρηση Αιτημάτων</h2>
				@include('includes.menu_leitourgies')
				@if(Request::path() == 'aitimata')
				<div id="aitimataShow" >
								<div class="table-responsive">
		    				 	<table id="mainTable" class="table table-bordered ">
		    				 		<thead>
		    						<tr>
		    								<th>ID</th>
		    								<th>Πελάτης</th>
		    								<th>Τίτλος</th>
		    								<th>Πρόοδος</th>
		    								<th>Σχόλια</th>
		    								<th>Ημερομηνία Υποβολής</th>
		    								<th>Ημερομηνία Εκπλήρωσης</th>
		    								<th>Ειδοποίηση</th>
		    								<th>Αποτέλεσμα</th>
		    						</tr>
		    					</thead>
		    					 <tbody> 
    				@foreach($aitimata as $aitima)  	
							       <tr>
							       		<td>{{$aitima->ait_id}}</td>
							       		<td style="cursor: pointer;">{{$aitima->p_id}}</td>
							       		<td>{{$aitima->Titlos}}</td>
							       		<td>{{$aitima->Proodos}}</td>
							       		<td>{{$aitima->Sxolia}}</td>
							       		<td>{{$aitima->Hmerominia_Ypovolis}}</td>
							       		<td>{{$aitima->Hmerominia_Ekplirosis}}</td>
							       		<td>{{$aitima->eidopoihsh}}</td>
							       		<td>{{$aitima->apotelesma}}</td>
							       		
							      </tr>
							    @endforeach
							    
							</tbody>
						</table>
							</div>
						</div>
					
				

<div id="aitimataAdd" >
								<form action="aitimaAdd" method="post">
									<div class=form-group>
    						<label for=ait_id>ID</label>
   								<input type=number class=form-control name=ait_id readonly>
  						</div>
								<div class=form-group>
    						<label for=p_id>Πελάτης</label>
   								<input type=number class=form-control name=p_id >
  						</div>
  						<div class=form-group>
						    <label for=Titlos>Τίτλος</label>
						    	<input type=text class=form-control name=Titlos>
  						</div>
  						<div class=form-group>
    						<label for=Proodos>Πρόοδος</label>
   								<input type=number class=form-control name=Proodos min=1 max=3>
  						</div>
  						<div class=form-group>
						    <label for=Sxolia>Σχόλια</label>
						    	<input type=text class=form-control name=Sxolia>
  						</div>
  						<div class=form-group>
    						<label for=Hmerominia_Ypovolis>Ημερομηνία Υποβολής</label>
   								<input type=date class=form-control name=Hmerominia_Ypovolis>
  						</div>
  						<div class=form-group>
						    <label for=Hmerominia_Ekplirosis>Ημερομηνία Εκπλήρωσης</label>
						    	<input type=date class=form-control name=Hmerominia_Ekplirosis>
  						</div>
  						<div class=form-group>
						    <label for=eidopoihsh>Ειδοποίηση</label>
						    	<input type=number class=form-control name=eidopoihsh>
  						</div>
  						<div class=form-group>
    						<label for=apotelesma>Αποτέλεσμα</label>
   								<input type=number class=form-control name=apotelesma>
  						</div>
  						
		<input class="btn btn-success" type="submit" value="Καταχώρηση"/>
		<input class="btn btn-info" type="reset" value="Καθαρισμός"/>
	</form>


						</div>

						<div id="aitimataEditUpdate">
							<form action="aitimaEditUpdate" method="post">
							<div class=form-group>
    						<label for=ait_id>ID</label>
   								<input type=number class=form-control name=ait_id readonly>
  						</div>
								<div class=form-group>
    						<label for=p_id>Πελάτης</label>
   								<input type=number class=form-control name=p_id >
  						</div>
  						<div class=form-group>
						    <label for=Titlos>Τίτλος</label>
						    	<input type=text class=form-control name=Titlos>
  						</div>
  						<div class=form-group>
    						<label for=Proodos>Πρόοδος</label>
   								<input type=number class=form-control name=Proodos min=1 max=3>
  						</div>
  						<div class=form-group>
						    <label for=Sxolia>Σχόλια</label>
						    	<input type=text class=form-control name=Sxolia>
  						</div>
  						<div class=form-group>
    						<label for=Hmerominia_Ypovolis>Ημερομηνία Υποβολής</label>
   								<input type=date class=form-control name=Hmerominia_Ypovolis>
  						</div>
  						<div class=form-group>
						    <label for=Hmerominia_Ekplirosis>Ημερομηνία Εκπλήρωσης</label>
						    	<input type=date class=form-control name=Hmerominia_Ekplirosis>
  						</div>
  						<div class=form-group>
						    <label for=eidopoihsh>Ειδοποίηση</label>
						    	<input type=number class=form-control name=eidopoihsh>
  						</div>
  						<div class=form-group>
    						<label for=apotelesma>Αποτέλεσμα</label>
   								<input type=number class=form-control name=apotelesma>
  						</div>
		<input class="btn btn-success" type="submit" value="Καταχώρηση"/>
		<input class="btn btn-info" type="reset" value="Καθαρισμός"/>
	</form>
						</div>

						<div id="aitimataDelete" >
							{{Form::open(['url'=>'aitimaDelete'])}}
								{{Form::label('ait_id','ID')}}
								{{Form::input('number','ait_id')}}
								{{Form::submit('Διαγραφή',['class' => 'btn  btn-success'])}}
							{{Form::close()}}
						</div>

@endif
			</div>


<script>
	$(document).ready(function(){

		hideAll()
	
	});

$("#provoli").click(function(){
	hideAll();
	$("#aitimataShow").show();
});

$("#kataxorisi").click(function(){
	hideAll();
	$("#aitimataAdd").show();
});

$("#epeksergasia").click(function(){
	hideAll();
	$("#aitimataEditUpdate").show();
});

$("#diagrafi").click(function(){
	hideAll();
	$("#aitimataDelete").show();
});


function hideAll(){
	
		$("#aitimataEditUpdate").hide();
		$("#aitimataDelete").hide();
		$("#aitimataAdd").hide();
}

$("tr").click(function(){
	var a = $(this).closest('tr').find('td:first').text();

 $.ajax({
            type:"POST",
            url:"aitimaEdit",
            data:{ait_id:a},
            success:function(data){
            var b = jQuery.parseJSON(data)
            $('input[name=p_id]').val(b.p_id);
            $('input[name=ait_id]').val(b.ait_id);
            $('input[name=Titlos]').val(b.Titlos);
            $('input[name=Proodos]').val(b.Proodos);
            $('input[name=Sxolia]').val(b.Sxolia);
            $('input[name=Hmerominia_Ekplirosis]').val(b.Hmerominia_Ekplirosis);
            $('input[name=Hmerominia_Ypovolis]').val(b.Hmerominia_Ypovolis);
            $('input[name=eidopoihsh]').val(b.eidopoihsh);
            $('input[name=apotelesma]').val(b.apotelesma);
           
              // alert(data);
             
             	
        }


            
        });

});

</script>



@stop

