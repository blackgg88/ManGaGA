import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css']
})

export class CarouselComponent implements OnInit {

  slides = [
    {img: "assets/omniscient_banner_Titulo-removebg-transparent.png"},
    {img: "assets/HMMD-YUGEN-1.png"},
    {img: "assets/Roxana-MangoScan_3-removebg-trans.png"},
    {img: "assets/estiobanner15.png"},
    {img: "assets/banner_villana_v3-2-4.png"}
  ];
  
  slideConfig = {
    "slidesToShow": 3, 
    "slidesToScroll": 1, 
    "dots": true,
    "arrows": false,
    "infinite": true, 
    "autoplay" : true, 
    "autoplaySpeed" : 3000,
    "centerMode" : true,    
    "variableWidth" : true,
    "pauseOnHover": true,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 1,          
          centerMode: true,
        },
      },
      {
        breakpoint: 600,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
          centerMode: false,
        },
      }
    ]};
  
  addSlide() {
    this.slides.push({img: "http://placehold.it/350x150/777777"})
  }
  
  removeSlide() {
    this.slides.length = this.slides.length - 1;
  }
  
  slickInit(e: any) {
    console.log('slick initialized');
  }
  
  breakpoint(e: any) {
    console.log('breakpoint');
  }
  
  afterChange(e: any) {
    console.log('afterChange');
  }
  
  beforeChange(e: any) {
    console.log('beforeChange');
  }

  constructor() { }

  ngOnInit(): void {
  }
}
