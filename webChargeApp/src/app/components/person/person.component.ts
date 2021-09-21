import { Component, Input, OnInit } from '@angular/core';

import { PersonphoneService } from '../../services/personphone.service';
import { Person } from '../../models/person.model';
import { PersonPhone } from '../../models/personphone.model';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  @Input() person: Person;

  initials: string;
  personPhones: PersonPhone[];

  personPhone: PersonPhone = {
    businessEntityId: 0,
    phoneNumber: '',
    phoneNumberTypeId: 0
  };

  constructor(private personphoneService: PersonphoneService) { }

  ngOnInit(): void {
    console.log("businessEntityId:" + this.person.businessEntityId);
    this.personPhone.businessEntityId = this.person.businessEntityId;

    let names: string[] = this.person.name.split(" ").map(n => n[0]);

    this.initials = names.length > 0
      ? `${names[0]}${names[names.length-1]}`.toUpperCase()
      : names[0].toUpperCase();

      this.initials = "CT";
      
    this.personphoneService.read(this.person.businessEntityId).subscribe(response => {
      if (response.data.success) {
        this.personPhones = response.data.personPhoneObjects;
      } 
      else {
        this.personphoneService.showSnackbarMessage(response.data.errors.join("\n"), true);
      }
    });
  }

  private createPersonPhone(): void {
    this.personphoneService.create(this.personPhone).subscribe(response => {
      if (response.data.success) {
        this.personphoneService.showSnackbarMessage('Phone number added successfully!');
        window.location.reload();
      } 
      else {
        this.personphoneService.showSnackbarMessage(response.data.errors.join("\n"), true);
      }
    });
  }

  create(): void {
    this.personphoneService.openInsertPersonPhoneDialog(this.personPhone).subscribe(confirmation => {
      if (confirmation) {
        this.createPersonPhone();
      }
    });
  }

}
