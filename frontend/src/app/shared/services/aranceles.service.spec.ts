import { TestBed } from '@angular/core/testing';

import { ArancelesService } from './aranceles.service';

describe('ArancelesService', () => {
  let service: ArancelesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ArancelesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
