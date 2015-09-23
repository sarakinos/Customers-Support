<?php 

class PagesController extends BaseController{

	public function index(){
		return View::make('pages.index');
	}
	
	public function pelates(){

		$pelates = Pelatis::All();

		return View::make('pages.pelates')->with('pelates',$pelates);
	}

	public function rantevou(){
		$rantevou = Rantevou::All();
		$pelates = Pelatis::All();
		return View::make('pages.rantevou')->with('rantevou',$rantevou)->with('pelates',$pelates);
	}
	public function eortologio(){
		return View::make('pages.eortologio');
	}
	public function aitimata(){

		$aitimata = Aitima::All();
		$pelates = Pelatis::All();
		return View::make('pages.aitimata')->with('aitimata',$aitimata)->with('pelates',$pelates);
	}
	public function leitourgies(){
		$pelates = Pelatis::All();
		return View::make('pages.leitourgies')->with('pelates',$pelates);
	}
}



?>