<?php

class AitimataController extends \BaseController {

	/**
	 * Display a listing of the resource.
	 *
	 * @return Response
	 */
	public function index()
	{
		//
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
		$aitima = new Aitima;
		$aitima->p_id = Input::get('p_id');
		$aitima->Titlos = Input::get('Titlos');
		$aitima->Proodos = Input::get('Proodos');
		$aitima->Hmerominia_Ekplirosis = Input::get('Hmerominia_Ekplirosis');
		$aitima->Hmerominia_Ypovolis = Input::get('Hmerominia_Ypovolis');
		$aitima->eidopoihsh = Input::get('eidopoihsh');
		$aitima->apotelesma = Input::get('apotelesma');
		$aitima->Sxolia = Input::get('Sxolia');
		
		
		$aitima->save();

		return Redirect::to('/aitimata');
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
	public function edit()
	{
		$ait_id = Input::get('ait_id');
		$aitima = Aitima::find($ait_id);
		//return $pelatis;
		return json_encode($aitima);
	}


	/**
	 * Update the specified resource in storage.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function update()
	{
		$ait_id = Input::get('ait_id');
		$aitima = Aitima::find($ait_id);

		$aitima->p_id = Input::get('p_id');
		$aitima->Titlos = Input::get('Titlos');
		$aitima->Proodos = Input::get('Proodos');
		$aitima->Hmerominia_Ekplirosis = Input::get('Hmerominia_Ekplirosis');
		$aitima->Hmerominia_Ypovolis = Input::get('Hmerominia_Ypovolis');
		$aitima->eidopoihsh = Input::get('eidopoihsh');
		$aitima->apotelesma = Input::get('apotelesma');
		$aitima->Sxolia = Input::get('Sxolia');
		
		
		$aitima->save();

		return Redirect::to('/aitimata');

	}


	/**
	 * Remove the specified resource from storage.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function destroy()
	{
		$ait_id = Input::get('ait_id');
		$aitima = Aitima::find($ait_id);
		$aitima->delete();
	

		return Redirect::to('/aitimata');
	}


}
