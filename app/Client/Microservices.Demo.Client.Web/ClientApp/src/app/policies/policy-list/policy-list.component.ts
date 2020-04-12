import { Component, OnInit } from '@angular/core';
import { PolicyService } from '../../services/data/policy.service';
import { IPolicy } from '../../models/ipolicy';

@Component({
  selector: 'app-policy-list',
  templateUrl: './policy-list.component.html',
  styleUrls: ['./policy-list.component.scss']
})
export class PolicyListComponent implements OnInit {

  policies: IPolicy[];

  constructor(private service: PolicyService) {
  }

  ngOnInit(): void {
    this.service.getPolicies().subscribe({
      next: (policies: IPolicy[]) => this.policies = policies,
      error: err => console.log(err)
    });
  }

}
