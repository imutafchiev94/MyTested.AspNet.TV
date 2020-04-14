import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'
import { CatService } from '../services/cat.service';

@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['./createpost.component.css']
})
export class CreatepostComponent {
  catForm: FormGroup;
  constructor(private fb: FormBuilder, private catService: CatService) { 
    this.catForm = this.fb.group({
      'ImageUrl': ['', Validators.required],
      'Description': ['']
    })
  }

  get imgaUrl() {
    return this.catForm.get('ImageUrl');
  }

  create() {
    this.catService.create(this.catForm.value).subscribe(res => {
      console.log(res);
    })
  }

}
