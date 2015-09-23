<?php

class EortologioController extends \BaseController {

	/**
	 * Display a listing of the resource.
	 *
	 * @return Response
	 */
	public function index()
	{
		
	}

	public function returnEorti(){

		$month = Input::get('month');
		$day = Input::get('day');

		//$eorti = DB::table('days')->whereday($day)->wheremonth($month)->get();
		$eorti = DB::select("select text from days where day='$day' and month='$month'");
		$eortiFinal = explode(",", $eorti[0]->text);
		$eortiFinal = str_replace(' ', '', $eortiFinal);
		$eortiFinal = str_replace('"',"'",$eortiFinal);
		//$pelatis = Pelatis::whereIn('Onoma', $eortiFinal)->get();

		$sql = "select * from pelates where FIND_IN_SET ( Onoma, ? ) ";  
$relatedUsers = DB::select( $sql,  $eortiFinal  );
		//return json_encode($pelatis);
		return $relatedUsers;
	}

	/**
	 * Show the form for creating a new resource.
	 *
	 * @return Response
	 */
	public function create()
	{
		//
	}


	/**
	 * Store a newly created resource in storage.
	 *
	 * @return Response
	 */
	public function store()
	{
		//
	}


	/**
	 * Display the specified resource.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function show($id)
	{
		//
	}


	/**
	 * Show the form for editing the specified resource.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function edit($id)
	{
		//
	}


	/**
	 * Update the specified resource in storage.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function update($id)
	{
		//
	}


	/**
	 * Remove the specified resource from storage.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function destroy($id)
	{
		//
	}


}
